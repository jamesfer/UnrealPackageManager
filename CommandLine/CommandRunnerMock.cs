using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnrealPackageManager.FileSystem;
using System.IO;

namespace UnrealPackageManager.CommandLine
{
	class CommandRunnerMock : ICommandRunner
	{
		List<string> commandHistory = new List<string>();


		public List<string> CommandHistory
		{
			get
			{
				return commandHistory;
			}
		}


		public CommandOutput RunCommand(string cmd, string args)
		{
			commandHistory.Add(cmd + " " + args);

			StreamReader stdOut = new StreamReader(new MemoryStream());
			StreamReader stdErr = new StreamReader(new MemoryStream());
			return new CommandOutput(stdOut, stdErr);
		}
	}
}
