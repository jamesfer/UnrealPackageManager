using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using Ninject;

namespace UnrealPackageManager
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
