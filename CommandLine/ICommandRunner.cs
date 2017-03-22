using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnrealPackageManager.FileSystem;

namespace UnrealPackageManager.CommandLine
{
	interface ICommandRunner
	{
		CommandOutput RunCommand(string cmd, string args);
	}
}
