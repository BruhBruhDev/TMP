using OpenHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace TMP
{
    class DataStore
    {
    }
	class StartProfile // manager values and how it should work
	{
		public static int
			percentUpper = 50,
			percentLower = 45,
			percentStep = 5,
			percentLimitMax = 90,
			percentLimitMin = 10,
			tempMax = 85,
			tempMin = 30,
			waitTime = 7500;

		public static void ApplyViaCMD()
        {
			CMD.SetMaxState(false, (uint)percentUpper, false);
			CMD.SetMaxState(true, (uint)percentUpper, false);
			CMD.SetMinState(false, (uint)percentLower, false);
			CMD.SetMinState(true, (uint)percentLower);
		}
	}
	class Config
	{
		public static int
			tempUpdateInterval = 200;
		public static bool
			managerRunning = false;
	}
	class Util
	{
		private static CpuDataReader CDR = new CpuDataReader();
		public static float GetMaxTemp(bool doUpdate)
		{
			IEnumerable<float> valueCollection;
			IReadOnlyDictionary<string, float> tempCollection = CDR.GetTemperaturesInCelsius(doUpdate);
			valueCollection = tempCollection.Values;
			float highestTemp = 0;
			foreach (float i in valueCollection) if (i > highestTemp) highestTemp = i;
			return highestTemp;
		}
		public static float GetClockSpeed(bool doUpdate)
        {
			return CDR.GetClockSpeed(doUpdate);
        }
		public static float GetLoad(bool doUpdate)
		{
			return CDR.GetLoad(doUpdate);
		}
		public static bool IsElevated()
		{
			return WindowsIdentity.GetCurrent().Owner
			.IsWellKnown(WellKnownSidType.BuiltinAdministratorsSid);

			//var id = WindowsIdentity.GetCurrent();
			//return id.Owner != id.User;
		}
	}
	
	internal sealed class CpuDataReader : IDisposable
	{
		private readonly Computer _computer;
		public CpuDataReader()
		{
			_computer = new Computer { CPUEnabled = true };
			_computer.Open();
		}
		Dictionary<string, float> coreAndTemperature = new Dictionary<string, float>();
		float clockSpeed = 0f;
		float load = 0f;
		public void UpdateData()
        {
			coreAndTemperature.Clear();
			clockSpeed = 0f;
			load = 0f;
			foreach (var hardware in _computer.Hardware)
			{
				hardware.Update();
				if (!hardware.Name.Contains("Intel")) // only intel supported for now
					return;
				foreach (var sensor in hardware.Sensors)
				{
					if (sensor.SensorType == SensorType.Temperature && sensor.Value.HasValue)
						coreAndTemperature.Add(sensor.Name, sensor.Value.Value);
					else if (sensor.SensorType == SensorType.Clock && sensor.Value.HasValue
						&& sensor.Name.Contains("CPU Core")
						&& sensor.Value.Value > clockSpeed)
						clockSpeed = sensor.Value.Value;
					else if (sensor.SensorType == SensorType.Load && sensor.Value.HasValue)
						load = sensor.Value.Value;
				}
			}
		}
		public IReadOnlyDictionary<string, float> GetTemperaturesInCelsius(bool doUpdate)
		{
			if (doUpdate) UpdateData();
			return coreAndTemperature;
		}
		public float GetClockSpeed(bool doUpdate)
		{
			if (doUpdate) UpdateData();
			return clockSpeed;
		}
		public float GetLoad(bool doUpdate)
		{
			if (doUpdate) UpdateData();
			return load;
		}
		public void Dispose()
		{
			try
			{
				_computer.Close();
			}
			catch (Exception)
			{
				//ignore closing errors
			}
		}
	}

}
