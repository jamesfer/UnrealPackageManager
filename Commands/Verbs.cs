using CommandLine;

namespace UnrealPackageManager.Commands
{
	class Verbs
	{
		[VerbOption("install", HelpText = "Install a package locally")]
		public InstallVerb Install { get; set; }
	}
}
