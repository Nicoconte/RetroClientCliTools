using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RetroClientCliTools.Helpers
{
	class PathHelper
	{
		public static string ROOT_PATH = Path.GetDirectoryName(System.AppContext.BaseDirectory);
		public static string GAME_SCRAPER_PATH = Path.Combine(ROOT_PATH,"Scripts/game_scraper.py");

		public static string GetPythonExePath()
		{
            var entries = Environment.GetEnvironmentVariable("path").Split(';');
            string pythonLocation = null;

            foreach (string entry in entries)
            {
                if (entry.ToLower().Contains("python"))
                {
                    var breadCrumbs = entry.Split('\\');
                    foreach (string breadCrumb in breadCrumbs)
                    {
                        if (breadCrumb.ToLower().Contains("python"))
                        {
                            pythonLocation += breadCrumb + '\\';
                            break;
                        }
                        pythonLocation += breadCrumb + '\\';
                    }
                    break;
                }
            }

            return pythonLocation;
        }
	}
}
