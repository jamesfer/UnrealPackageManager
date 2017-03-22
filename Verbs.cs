using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;

namespace UnrealPackageManager
{
	class Verbs
	{
		[VerbOption("install", HelpText = "Install a package locally")]
		public InstallVerb Install { get; set; }
	}
}
