using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnrealPackageManager.FileSystem;

namespace UnrealPackageManager.CommandLine
{
	class GitCommandRunner : IGitCommandRunner
	{
		protected CommandRunner commandRunner;


		public GitCommandRunner(CommandRunner commandRunner)
		{
			this.commandRunner = commandRunner;
		}


		public void Clone(string cloneURL, IDirectory target, bool shallowClone = true)
		{
			//commandRunner.RunCommand("git", )
		}
	}
}
