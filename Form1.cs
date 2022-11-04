using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TMP
{
	public partial class Form1 : Form
	{
		
		public Form1()
		{
			InitializeComponent();
		}
		private void Form1_Load(object sender, EventArgs e)
		{
			Environment.ExitCode = -1000;
			
			if (!Util.IsElevated())
				lbl_IsNotElevated.Text = "Program is not elevated. To resolve the issue restart with admin permissions.";

			OverwriteBoxesGroupA(true, false);
			
			CMD.INIT();
			CMD.RetrieveWPPs();
			CMD.CreatePP();
			StartProfile.ApplyViaCMD();

			timer_ValueUpdater.Interval = 21;
			//timer_ValueUpdater.Start();

			timer_Controller.Interval = StartProfile.waitTime;
			lastShift = DateTime.Now;
			lastTemp = DateTime.Now;
			//timer_Controller.Start();

		}
		private void Form1_FormClosed(object sender, FormClosedEventArgs e)
		{
			CMD.TERMINATE(2000);
			Environment.ExitCode = 0;
		}

		private static int _runningPercent = (int)StartProfile.percentUpper;

		private DateTime lastShift;
		private DateTime lastTemp;

		private static double _averageTemp = 0;
		private static float[] _tempArray = new float[20];
		private static int _tempArray_i = 0;

		// uses cmdcall at shift time
		private async void timer_Controller_Tick(object sender, EventArgs e)
		{
			timer_Controller.Stop();
			int option = 0; // could be optimised into a bool; but currently is more readable
			while (true) // will loop until it either downshifts or upshitfs
			{
				if (
					(_averageTemp > StartProfile.tempMax || StartProfile.tempMax > StartProfile.percentLimitMax)
					&& StartProfile.percentLower - StartProfile.percentStep >= StartProfile.percentLimitMin)
				{
					StartProfile.percentUpper -= StartProfile.percentStep;
					StartProfile.percentLower -= StartProfile.percentStep;
					option = 1;
				}
				else if (
					(_averageTemp < StartProfile.tempMin || StartProfile.tempMin < StartProfile.percentLimitMin)
					&& StartProfile.percentUpper + StartProfile.percentStep <= StartProfile.percentLimitMax)
				{
					StartProfile.percentUpper += StartProfile.percentStep;
					StartProfile.percentLower += StartProfile.percentStep;
					option = 2;
				}
				else 
				{
					await Task.Delay(50);
					continue;
				}
				
				CMD.SetMaxState(false, (uint)StartProfile.percentUpper, false);
				CMD.SetMaxState(true, (uint)StartProfile.percentUpper, false);
				CMD.SetMinState(false, (uint)StartProfile.percentLower, false);
				CMD.SetMinState(true, (uint)StartProfile.percentLower);

				break;
				
				// powercfg -setacvalueindex SCHEME_CURRENT 54533251-82be-4824-96c1-47b60b740d00 75b0ae3f-bce0-45a7-8c89-c9611c25e100 <MHz>
			}
			lastShift = DateTime.Now;
			timer_Controller.Interval = StartProfile.waitTime;
			timer_Controller.Start();


			if (option == 1)
				lbl_ArrowDown.BorderStyle = BorderStyle.Fixed3D;
			else
				lbl_ArrowUp.BorderStyle = BorderStyle.Fixed3D;
			await Task.Delay((int)(StartProfile.waitTime / 5));
			if (option == 1)
				lbl_ArrowDown.BorderStyle = BorderStyle.FixedSingle;
			else
				lbl_ArrowUp.BorderStyle = BorderStyle.FixedSingle;

		}
		// does not change pps / only updates values
		private void timer_ValueUpdater_Tick(object sender, EventArgs e)
		{
			// running visual timer
			int num = (int)DateTime.Now.Subtract(lastShift).TotalMilliseconds;
			if (num > 60000)
				lbl_CycleTime.Text = "60s+";
			else if (num > 10000)
				lbl_CycleTime.Text = (num / 1000.0).ToString("00.00");
			else
				lbl_CycleTime.Text = num.ToString();
			if (num > StartProfile.waitTime)
			{
				lbl_ArrowUp.ForeColor = Color.Black;
				lbl_ArrowDown.ForeColor = Color.Black;
				lbl_CycleTime.ForeColor = Color.Black;
			}
			else
			{
				lbl_ArrowUp.ForeColor = Color.DimGray;
				lbl_ArrowDown.ForeColor = Color.DimGray;
				lbl_CycleTime.ForeColor = Color.DimGray;
			}

            // last wpp reactivation
            {
				DateTime dt = CMD.lastWPPUpdate;
				lblWPPUpdate.Text = "Last update: "+dt.Hour.ToString("00")+":"+dt.Minute.ToString("00")+":"+dt.Second.ToString("00");
			}

			// new cpu data / temp data
			if ((int)DateTime.Now.Subtract(lastTemp).TotalMilliseconds > Config.tempUpdateInterval)
			{
				_tempArray[++_tempArray_i % _tempArray.Length] = Util.GetMaxTemp(true);
				float sum = 0;
				for (int i = 0; i < _tempArray.Length; i++)
					sum += _tempArray[i];
				_averageTemp = (double)sum / _tempArray.Length;
				lastTemp = DateTime.Now;

				// display of new value
				lbl_Temp.Text = _averageTemp + " C°";
				if (_averageTemp > StartProfile.tempMax)
				{
					lbl_TempDirection.Text = "HOT";
					lbl_TempDirection.ForeColor = Color.OrangeRed;
				}
				else if (_averageTemp <= StartProfile.tempMax && _averageTemp >= StartProfile.tempMin)
				{
					lbl_TempDirection.Text = "---";
					lbl_TempDirection.ForeColor = Color.Gray;
				}
				else if (_averageTemp < StartProfile.tempMin)
				{
					lbl_TempDirection.Text = "COLD";
					lbl_TempDirection.ForeColor = Color.Blue;
				}
				lblClockSpeed.Text = ((int)Util.GetClockSpeed(false)+0.5f).ToString("###0")+" MHz";
				int load = (int)Util.GetLoad(false);
				lblLoad.Text = load.ToString("00")+"%";
				lblLoadBar.Text = new string('O', (load+5) / 10);

			}

			// adding temp values
			CanvasProp.timestamp.Add(DateTime.Now);
			CanvasProp.tempVal.Add(_averageTemp);
			if (DateTime.Now.Subtract(CanvasProp.timestamp[0]).TotalMilliseconds > CanvasProp.logBufferSec*1000)
            {
				CanvasProp.tempVal.RemoveAt(0);
				CanvasProp.timestamp.RemoveAt(0);
			}
			// updating temp
			txtBx_LowerP.Text = StartProfile.percentLower.ToString();
			txtBx_UpperP.Text = StartProfile.percentUpper.ToString();
			
			// canvas refresh
			if (cou++ > 20)
            {
				cou = 0;
				canvas.Refresh();
			}
			
		}
		int cou = 0;
		private void canvas_Paint(object sender, PaintEventArgs e)
		{
			Graphics G = e.Graphics;
			if (false)
            {
				G.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
				G.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
			}
            else
            {
				G.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
				G.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighSpeed;
			}




			int winX = e.ClipRectangle.Width, winY = e.ClipRectangle.Height;
			int cellsVert = 12, cellsHori = 40;
			float cellSizeX = (float)winX/cellsHori, cellSizeY = (float)winY/cellsVert;

			Brush bruhBlack = new SolidBrush(Color.Gray);
			Brush bruhDarkGray = new SolidBrush(Color.DarkGray);
			
			bool b;
            for (int i = 0; i < cellsVert; i++)
                for (int i2 = 0; i2 < cellsHori; i2++)
                {
					b = (i+i2) % 2 == 0;
					G.FillRectangle(b?bruhBlack:bruhDarkGray, i2 * cellSizeX, i * cellSizeY, cellSizeX, cellSizeY);
                }

			// temp bounds bars
			var pTMax = CanvasProp.GetScreenPos_Temp(new TimeSpan(0), winX, winY, StartProfile.tempMax);
			var pTMin = CanvasProp.GetScreenPos_Temp(new TimeSpan(0), winX, winY, StartProfile.tempMin);
			G.FillRectangle(Brushes.DarkRed, 0, pTMax.Y - 1, winX, 3);
			G.FillRectangle(Brushes.DarkRed, 0, pTMin.Y - 1, winX, 3);
			G.DrawLine(Pens.Black, 0, pTMax.Y, winX, pTMax.Y);
			G.DrawLine(Pens.Black, 0, pTMin.Y+1, winX, pTMin.Y+1);

			// temp values
			DateTime dtNow = DateTime.Now;
			for (int i = 0; i < CanvasProp.tempVal.Count; i++)
            {
				var p = CanvasProp.GetScreenPos_Temp(dtNow.Subtract(CanvasProp.timestamp[i]), winX, winY, (float)CanvasProp.tempVal[i]);
				G.FillRectangle(Brushes.Red, p.X, p.Y, 1, 1);
            }
			

		}
		class CanvasProp
		{
			public static int logBufferSec = 12;
			public static int maxVal = 75;
			public static int minVal = 55;
			public static List<DateTime> timestamp = new List<DateTime>();
			public static List<double> tempVal = new List<double>();


			public static (float X, float Y) GetScreenPos_Temp(TimeSpan ts, int winX, int winY, float temp)
            {
				int length = winX;
				float percent = (float)ts.TotalMilliseconds / (logBufferSec * 1000);
				float x = winX - length * percent;
				float y = winY - winY * (temp - minVal) / (maxVal - minVal);
				return (x, y);
            }
		}

		private Color colorBtn = Color.FromKnownColor(KnownColor.Gainsboro);
		private Color colorPink = Color.FromArgb(255, 192, 255);
		private Color colorTxtBx = Color.FromKnownColor(KnownColor.Window);
		private int counter_changes = 0;
		private void TxtBx_Instructions_TextChanged(ref MaskedTextBox txtBx, ref int var)
		{
			if (txtBx.Text == "") txtBx.Text = "0";
			int num = Convert.ToInt32(txtBx.Text);
			if (num == var)
			{
				if (txtBx.BackColor != colorTxtBx)
					counter_changes--;
				txtBx.BackColor = colorTxtBx;
			}
			else
			{
				if (txtBx.BackColor != colorPink)
					counter_changes++;
				txtBx.BackColor = colorPink;
			}

			if (counter_changes > 0)
			{
				btn_Apply.BackColor = colorPink;
				btn_Cancel.BackColor = colorPink;
			}
			else
			{
				btn_Apply.BackColor = colorBtn;
				btn_Cancel.BackColor = colorBtn;
			}
		}
		#region txtBx Text Changed
		private void txtBx_UpperP_TextChanged(object sender, EventArgs e)
		{
			if (!Config.managerRunning)
				TxtBx_Instructions_TextChanged(ref txtBx_UpperP, ref StartProfile.percentUpper);
		}
		private void txtBx_LowerP_TextChanged(object sender, EventArgs e)
		{
			if (!Config.managerRunning)
				TxtBx_Instructions_TextChanged(ref txtBx_LowerP, ref StartProfile.percentLower);
		}
		
		private void InvDec_LimitMaxP_ValueChanged(object sender, EventArgs e)
		{

		}
		// ... ----

		private void txtBx_LimitMaxP_TextChanged(object sender, EventArgs e)
		{
			TxtBx_Instructions_TextChanged(ref txtBx_LimitMaxP, ref StartProfile.percentLimitMax);
		}
		private void txtBx_LimitMinP_TextChanged(object sender, EventArgs e)
		{
			TxtBx_Instructions_TextChanged(ref txtBx_LimitMinP, ref StartProfile.percentLimitMin);
		}

		private void txtBx_MaxTemp_TextChanged(object sender, EventArgs e)
		{
			TxtBx_Instructions_TextChanged(ref txtBx_MaxTemp, ref StartProfile.tempMax);
		}
		private void txtBx_MinTemp_TextChanged(object sender, EventArgs e)
		{
			TxtBx_Instructions_TextChanged(ref txtBx_MinTemp, ref StartProfile.tempMin);
		}

		private void txtBx_WaitTime_TextChanged(object sender, EventArgs e)
		{
			TxtBx_Instructions_TextChanged(ref txtBx_WaitTime, ref StartProfile.waitTime);
		}
		
		#endregion

		private void chBx_ToggleManager_CheckedChanged(object sender, EventArgs e)
		{
			Config.managerRunning = chBx_ToggleManager.Checked;
			bool b = Config.managerRunning;
			if (b)
			{
				lastShift = DateTime.Now;
				lastTemp = DateTime.Now;
			}
			timer_Controller.Enabled = b;
			timer_ValueUpdater.Enabled = b;
			if (!b)
				lbl_CycleTime.Text = "0000";
			txtBx_UpperP.ReadOnly = b;
			txtBx_LowerP.ReadOnly = b;
			IncDec_UpperP.ReadOnly = b;
			IncDec_LowerP.ReadOnly = b;
			chBx_CarryLower.AutoCheck = !b;
			txtBx_UpperP.BackColor = b ? Color.Gray : Color.White;
			txtBx_LowerP.BackColor = b ? Color.Gray : Color.White;
		}

		private void btn_Apply_Click(object sender, EventArgs e)
		{
			int max = StartProfile.percentUpper, min = StartProfile.percentLower;

			CheckAllInputsAndWriteToDataStore();

			if (counter_changes != 0)
            {
				if (max != StartProfile.percentUpper)
                {
					CMD.SetMaxState(false, (uint)StartProfile.percentUpper, false);
					CMD.SetMaxState(true, (uint)StartProfile.percentUpper);
					
				} else if (min != StartProfile.percentLower)
                {
					CMD.SetMinState(false, (uint)StartProfile.percentLower, false);
					CMD.SetMinState(true, (uint)StartProfile.percentLower);
				}
			}

			OverwriteBoxesGroupA(true, true);
			btn_Apply.BackColor = colorBtn;
			btn_Cancel.BackColor = colorBtn;
			counter_changes = 0;
		}

		private void btn_Cancel_Click(object sender, EventArgs e)
		{
			OverwriteBoxesGroupA(true, true);
			btn_Apply.BackColor = colorBtn;
			btn_Cancel.BackColor = colorBtn;
			counter_changes = 0;
		}

		private void OverwriteBoxesGroupA(bool resetText, bool resetColor)
        {
			if (resetText)
            {
				txtBx_UpperP.Text = StartProfile.percentUpper.ToString();
				txtBx_LowerP.Text = StartProfile.percentLower.ToString();
				//  txtBx...
				txtBx_LimitMaxP.Text = StartProfile.percentLimitMax.ToString();
				txtBx_LimitMinP.Text = StartProfile.percentLimitMin.ToString();
				txtBx_MaxTemp.Text = StartProfile.tempMax.ToString();
				txtBx_MinTemp.Text = StartProfile.tempMin.ToString();
				txtBx_WaitTime.Text = StartProfile.waitTime.ToString();
			}
			if (resetColor)
            {
				if (!Config.managerRunning) txtBx_UpperP.BackColor = colorTxtBx;
				if (!Config.managerRunning) txtBx_LowerP.BackColor = colorTxtBx;
				//
				txtBx_LimitMaxP.BackColor = colorTxtBx;
				txtBx_LimitMinP.BackColor = colorTxtBx;
				txtBx_MaxTemp.BackColor = colorTxtBx;
				txtBx_MinTemp.BackColor = colorTxtBx;
				txtBx_WaitTime.BackColor = colorTxtBx;
			}
		}
		private void CheckAllInputsAndWriteToDataStore()
        {
			int a, b;

			// cpu max min cpu p%
			a = Convert.ToInt32(txtBx_LimitMaxP.Text);
			b = Convert.ToInt32(txtBx_LimitMinP.Text);
			if (a >= b)
			{
				StartProfile.percentLimitMax = Math.Max(Math.Min(a, 100), 5);
				StartProfile.percentLimitMin = Math.Max(Math.Min(b, 100), 5);
			}
			IncDec_LimitMaxP.Value = StartProfile.percentLimitMax;
			IncDec_LimitMinP.Value = StartProfile.percentLimitMin;
			
			// cpu p%
			a = Convert.ToInt32(txtBx_UpperP.Text);
			b = Convert.ToInt32(txtBx_LowerP.Text);
			if (a >= b)
            {
				StartProfile.percentUpper = Math.Max(Math.Min(a, StartProfile.percentLimitMax), StartProfile.percentLimitMin);
				StartProfile.percentLower = Math.Max(Math.Min(b, StartProfile.percentLimitMax), StartProfile.percentLimitMin);
            }
			IncDec_UpperP.Value = StartProfile.percentUpper;
			IncDec_LowerP.Value = StartProfile.percentLower;

			// temp bounds
			a = Convert.ToInt32(txtBx_MaxTemp.Text);
			b = Convert.ToInt32(txtBx_MinTemp.Text);
			if (a >= b)
			{
				StartProfile.tempMax = Math.Max(Math.Min(a, 150), 0);
				StartProfile.tempMin = Math.Max(Math.Min(b, 150), 0);
			}
			IncDec_Temp.Value = StartProfile.tempMax;

			// time shift
			a = Convert.ToInt32(txtBx_WaitTime.Text);
			StartProfile.waitTime = a > 100 ? a : 100;
			
		}

    }

}
