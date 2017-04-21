using System.Collections.Generic;
using CommandLine;
using Ninject;
using UnrealPackageManager.Operations;

namespace UnrealPackageManager.Commands
{
	class InstallVerb : IVerb
	{
		[ValueList(typeof(List<string>))]
		public IList<string> PackageStrings { get; set; }


		public void Execute(IKernel kernel)
		{
			Installer installer = kernel.Get<Installer>();

			foreach (string PackageString in PackageStrings)
			{
				installer.Install(PackageRef);
			}
		}
	}
}
