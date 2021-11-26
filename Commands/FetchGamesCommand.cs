using CommandLine;
using RetroClient.Data;
using RetroClient.Services;
using RetroClientCliTools.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroClientCliTools.Commands
{
	[Verb("fetch-games", HelpText = "Fetch games from database")]
	public class FetchGamesCommand : ICommand
	{
		public async void Execute(ApplicationDbContext context)
		{

			LoggerHelper.LogTime("start");

			VideoGameService service = new VideoGameService(context);

			var games = await service.ListGames();

			foreach(var game in games)
			{
				Console.WriteLine($"Id: {game.Id} - Name: {game.Name} - Platform: {game.Platform} - Source: {game.SourceUrl}");
			}

			LoggerHelper.LogTime("end");
		}
	}
}
