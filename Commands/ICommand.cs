using RetroClient.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroClientCliTools.Commands
{
	public interface ICommand
	{
		void Execute(ApplicationDbContext context);
	}
}
