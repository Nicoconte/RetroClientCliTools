using CommandLine;
using HtmlAgilityPack;
using RetroClient.Data;
using RetroClientCliTools.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroClientCliTools.Commands
{
	[Verb("scraping", HelpText = "Scrap content from page by url")]
	public class ScrapGamesCommand : ICommand
	{

		[Option('u', "url", Required = true, HelpText = "Url from page to scrap")]
		public string Url { get; set; }

		[Option('p', "platform", Required = true, HelpText = "Platform destinated")]
		public string Platform { get; set; }

		[Option('o', "output", Required = true, HelpText = "Set output folder and file")]
		public string Output { get; set; }

		public void Execute(ApplicationDbContext context)
		{

			LoggerHelper.LogTime("start");

			var web = new HtmlWeb();
			var doc = web.Load(Url);

			var nodes = doc
				.DocumentNode
				.SelectNodes("//a[contains(@class, 'index gamelist')]")
				.ToList();


			string nodeContent = string.Empty;

			foreach (var node in nodes)
			{
				var source = node.Attributes["href"].Value;
				var gameId = source.Split('/')[3];
				var name = node.InnerText;

				nodeContent += $"{Guid.NewGuid()};{name};https://www.emuparadise.me{source};http://emuparadise.me/roms/get-download.php?gid={gameId}&test=true;{Platform}\n";

			}

			File.WriteAllText(Output, nodeContent);

			LoggerHelper.LogTime("end");
		}
	}
}
