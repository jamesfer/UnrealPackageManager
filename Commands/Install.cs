using System.Collections.Generic;
using CommandLine;
using Ninject;

namespace UnrealPackageManager.Commands
{
	class InstallVerb : IVerb
	{
		[ValueList(typeof(List<string>))]
		public IList<string> Packages { get; set; }


		public void Execute(IKernel kernel)
		{
			Installer installer = kernel.Get<Installer>();

			foreach (string PackageRef in Packages)
			{
				installer.Install(PackageRef);
			}
		}
	}
}
