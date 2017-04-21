using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnrealPackageManager.Operations
{
	/**
	 * Is responsible for downloading modules from an online repository source and install them locally.
	 */
	class Installer
	{
		PackageResolver resolver;
		Project project;

		public Installer(PackageResolver resolver, Project project)
		{
			this.resolver = resolver;
			this.project = project;
		}

		public void Install(string packageString)
		{
			// Parse the package ref
			PackageRequest packageRequest = resolver.ResolvePackageReference(packageString);

			Console.WriteLine("Installing package: " + packageRequest.RequestedPackage.Name);

			// Install the package
			project.LocalRegistry.AddPackage(packageRequest);

			// translate string into module reference (normalize format, in this case just turn it into a github url)
			// determine the destination folder based on the package reference
			// create destination
			// clone repository into destination
			// add package into build scripts
			// finish
		}
	}
}
