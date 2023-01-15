using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TMP
{
    internal class Actor
    {
    }
	class _Names
	{
		public static string
			WPP_Name = "TMP",
			WPP_Desc = "This is a TMP-managed powerplan. Do not modify";
	}
	class CMD
	{
		private static ProcessStartInfo startInfo = new ProcessStartInfo();
		private static Process process_CMDCall = new Process();
		private static System.IO.StreamWriter process_CMDCall_sw;
		private static System.IO.StreamReader process_CMDCall_sr;
		private static int CmdOutputWaitInterval = 1000;

		public static void INIT()
		{
			startInfo.FileName = "cmd.exe";
			startInfo.Arguments = "";
			startInfo.WindowStyle = ProcessWindowStyle.Hidden;
			startInfo.UseShellExecute = false;

			startInfo.RedirectStandardInput = true;
			startInfo.RedirectStandardOutput = true;
			startInfo.CreateNoWindow = true;

			process_CMDCall.StartInfo = startInfo;
			process_CMDCall.Start();

			process_CMDCall_sw = process_CMDCall.StandardInput;

			process_CMDCall.OutputDataReceived += new DataReceivedEventHandler(ProcessDataReceived.Process_OutputDataReceived);

			//process_CMDCall.BeginOutputReadLine();

		}
		public static void TERMINATE(int wait_ms)
        {
			bool success = process_CMDCall.WaitForExit(wait_ms);
			if (!success)
				process_CMDCall.Kill();
		}
		public static void CreatePP()
		{
			if (schemeGUID.Count == 0)
				return;

			if (ourWPP != -1)
			{
				// maybe nothing ??
			}
			else
			{
				WaitForProcessToIdle(CmdReadMode.WPPClone);

				process_CMDCall_sw.WriteLine("powercfg /duplicatescheme " + schemeGUID[selectedScheme]);

				WaitForReadingToFinish(CmdReadMode.WPPClone);

				string WPPClone_GUID = cmdReturnValue;
				cmdReturnValue = String.Empty;

				cmdComVar = 100;
				process_CMDCall_sw.WriteLine("powercfg /changename " + WPPClone_GUID + " \"" + _Names.WPP_Name + "\" \""+_Names.WPP_Desc+"\"");

				WaitForReadingToFinish(CmdReadMode.WPPClone);

				schemeGUID.Add(WPPClone_GUID);
				schemeName.Add(_Names.WPP_Name);
				ourWPP = schemeName.Count - 1;
				cmdMode = CmdReadMode._idle;
			}
		}
		private static void WaitForReadingToFinish(CmdReadMode currentMode)
        {
			while (cmdMode != CmdReadMode._finishedReading)
            {
				ProcessDataReceived.CheckIfReadingHasFinished();
				Thread.Sleep(10);
			}
			cmdMode = currentMode;
		}
		private static void WaitForProcessToIdle(CmdReadMode currentMode)
		{
			while (cmdMode != CmdReadMode._idle)
				Thread.Sleep(10);
			cmdMode = currentMode;
		}
		static List<string> schemeGUID;
		static List<string> schemeName;
		static int selectedScheme;
		static int ourWPP; // wpp of the tmp
		public static DateTime lastWPPUpdate = DateTime.Now; // updates every time wpp is reactivated
		public static string GetCurrentWPP()
        {
			return selectedScheme == -1 ? "Not detected" : schemeName[selectedScheme];
        }
		public static void RetrieveWPPs()
		{
			selectedScheme = -1;
			ourWPP = -1;
			schemeGUID = new List<string>();
			schemeName = new List<string>();

			process_CMDCall_sw.FlushAsync();
			process_CMDCall.BeginOutputReadLine();

			Thread.Sleep(1000);

			cmdMode = CmdReadMode.WPPList;
			process_CMDCall_sw.WriteLine("powercfg /list");

			WaitForReadingToFinish(CmdReadMode.WPPList);
			cmdMode = CmdReadMode._idle;

		}
		enum CmdReadMode
		{
			_idle,
			_finishedReading,
			WPPList,
			WPPClone
		}
		static CmdReadMode cmdMode = CmdReadMode._idle;
		static string cmdReturnValue = String.Empty;
		static int cmdComVar = 0;
		static class ProcessDataReceived
		{
			static DateTime dtLastDataReceived = DateTime.MinValue, dtSecondLastDataReceived = DateTime.MinValue;
			static TimeSpan tsLast = TimeSpan.Zero, tsSecondLast = TimeSpan.Zero;
			static void noteLastDataReceived(bool reset = false)
			{
				dtSecondLastDataReceived = reset ? DateTime.MinValue : dtLastDataReceived;
				dtLastDataReceived = reset ? DateTime.MinValue : DateTime.Now;
				if (reset || dtSecondLastDataReceived != DateTime.MinValue)
                {
					tsSecondLast = reset ? TimeSpan.Zero : tsLast;
					tsLast = reset ? TimeSpan.Zero : dtLastDataReceived.Subtract(dtSecondLastDataReceived);
				}
			}
			public static void Process_OutputDataReceived(object sender, DataReceivedEventArgs e)
			{
				switch (cmdMode)
				{
					case CmdReadMode._idle:
						break;
					case CmdReadMode.WPPList:

						if (e.Data.StartsWith("Power Scheme GUID: "))
						{
							schemeGUID.Add(e.Data.Substring(19, 36));
							string txt = e.Data.Substring(58);
							if (txt.EndsWith(") *"))
							{
								txt = txt.Remove(txt.Length - 3);
								selectedScheme = schemeGUID.Count - 1;
							}
							else
								txt = txt.Remove(txt.Length - 1);
							schemeName.Add(txt);
							if (txt == _Names.WPP_Name) // TODO: potential for issues, if multiples found with the same name --> solution: add an if (not -1) { add index to an list of bad PP }
								ourWPP = schemeName.Count - 1;
						}
						noteLastDataReceived();
						break;
					case CmdReadMode.WPPClone:
						if (e.Data.StartsWith("Power Scheme GUID: "))
                        {
							cmdReturnValue = e.Data.Substring(19, 36);
							cmdMode = CmdReadMode._finishedReading;
						}
						else if (cmdComVar == 100 && e.Data == "")
							cmdMode = CmdReadMode._finishedReading;
						break;
				}
			}
			public static bool CheckIfReadingHasFinished()
            {
				// timeout
				if (dtLastDataReceived != DateTime.MinValue
					&& DateTime.Now > dtLastDataReceived.AddSeconds(10))
                {
					noteLastDataReceived(true);
					cmdMode = CmdReadMode._finishedReading;
					return true;
				}

				if (dtSecondLastDataReceived == DateTime.MinValue)
					return cmdMode == CmdReadMode._finishedReading;
				else if (DateTime.Now > dtLastDataReceived.Add(new TimeSpan(tsLast.Ticks*15)))
                {
					noteLastDataReceived(true);
					cmdMode = CmdReadMode._finishedReading;
					return true;
                }
				return false;
            }
		}
		public static void SetMaxState(bool ACinsteadOfDC, uint percent, bool reactivate = true)
		{
			SetCPUState(true, percent, ACinsteadOfDC, reactivate);
		}
		public static void SetMinState(bool ACinsteadOfDC, uint percent, bool reactivate = true)
        {
			SetCPUState(false, percent, ACinsteadOfDC, reactivate);
		}
		private static void SetCPUState(bool MaxInsteadOfMin, uint percent, bool ACinsteadOfDC = true, bool reactivate = true)
        {
			if (ourWPP == -1) return;

			startInfo.WindowStyle = ProcessWindowStyle.Hidden;
			startInfo.FileName = "cmd.exe";
			startInfo.Arguments =
				"/C powercfg -set" + (ACinsteadOfDC ? "AC" : "DC")
				+ "valueindex " + schemeGUID[ourWPP] + " SUB_PROCESSOR PROCTHROTTLE"
				+ (MaxInsteadOfMin ? "MAX" : "MIN") + " "
				+ (percent > 100 ? 100 : percent).ToString();

			process_CMDCall.StartInfo = startInfo;

			WaitForProcessToIdle(CmdReadMode._idle); // TODO may have problems

			process_CMDCall.Start();
			if (reactivate)
				ReactivateWPPToUpdate();

		}
		private static void ReactivateWPPToUpdate()
        {
			if (ourWPP == -1) return;

			startInfo.WindowStyle = ProcessWindowStyle.Hidden;
			startInfo.FileName = "cmd.exe";
			startInfo.Arguments = "/C powercfg -setactive " + schemeGUID[ourWPP];
			process_CMDCall.StartInfo = startInfo;

			WaitForProcessToIdle(CmdReadMode._idle); // TODO create queque for one line commands without return values
			selectedScheme = ourWPP;
			lastWPPUpdate = DateTime.Now;
			process_CMDCall.Start();
		}
	}
}
