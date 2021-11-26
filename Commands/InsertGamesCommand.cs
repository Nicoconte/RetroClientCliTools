using CommandLine;

using RetroClient.Data;
using RetroClient.Models;
using RetroClient.Services;
using RetroClientCliTools.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RetroClientCliTools.Commands
{
	[Verb("insert-games", HelpText = "Retrieve games from .txt file and save it in the database")]
	public class InsertGamesCommand : ICommand
	{

		[Option('f', "file", Required = true, HelpText = ".txt file with games")]
		public string FilePath { get; set; }

		public void Execute(ApplicationDbContext context)
		{
			LoggerHelper.LogTime("start");

			if(!Path.GetExtension(FilePath).Equals(".txt"))
			{
				throw new Exception("Only .txt files are allowed");
			}

			VideoGameService service = new VideoGameService(context);

			List<string> fileContent = File.ReadAllLines(FilePath).ToList();

			List<List<string>> contentParsed = new List<List<string>>();

			foreach(var content in fileContent)
			{
				contentParsed.Add(content.Split(';').ToList());
			}


			foreach(var content in contentParsed.Take(20))
			{
				Console.WriteLine($"Current Game {content[1]} - ID {content[0]}");

				service.InsertGame(new VideoGame()
				{
					Id = content[0],
					Name = content[1],
					Platform = content[4],
					SourceUrl = content[2],
					DownloadUrl = content[3]
				});
			}

			LoggerHelper.LogTime("end");
		}
	}
}
