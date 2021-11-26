using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroClientCliTools.Helpers
{
	class LoggerHelper
	{
		public static void LogTime(string time)
		{
			if (time.ToLower().Equals("start"))
			{
				Console.WriteLine($"Process started at {DateTime.Now}");
				return;
			}

			if (time.ToLower().Equals("end"))
			{
				Console.WriteLine($"Process ended at {DateTime.Now}");
				return;
			}
		}
	}
}
