using System;
using CommandLine;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RetroClient.Data;
using RetroClient.Services;
using RetroClientCliTools.Commands;

namespace RetroClientCliTools
{
	class Program
	{
		private static ApplicationDbContext _context;

		static void Main(string[] args)
		{
			var services = new ServiceCollection();

			services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite("Data source=D:/GIT/_me/RetroClient/RetroClientDB.db"));

			var serviceProvider = services.BuildServiceProvider();

			_context = serviceProvider.GetService<ApplicationDbContext>();

			Parser.Default.ParseArguments<InsertGamesCommand, ScrapGamesCommand, FetchGamesCommand>(args)
				.WithParsed<ICommand>(t => t.Execute(_context));
		}
	}
}
