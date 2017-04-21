using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnrealPackageManager.FileSystem;
using System.Diagnostics;

namespace UnrealPackageManager.CommandLine
{
	class CommandRunner : ICommandRunner
	{
		public CommandOutput RunCommand(string cmd, string args)
		{
			ProcessStartInfo startInfo = new ProcessStartInfo(cmd, args)
			{
				ErrorDialog = false,
				UseShellExecute = false,
				CreateNoWindow = true,
				RedirectStandardInput = true,
				RedirectStandardOutput = true,
				RedirectStandardError = true,
			};
			Process process = new Process();
			process.StartInfo = startInfo;
			process.Start();
			process.WaitForExit();

			CommandOutput output = new CommandOutput(process.StandardOutput, process.StandardError);
			return output;
		}
	}
}
