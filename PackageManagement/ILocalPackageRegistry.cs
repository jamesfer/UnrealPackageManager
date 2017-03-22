using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnrealPackageManager.PackageManagement
{
	interface ILocalPackageRegistry
	{
		List<PackageReference> GetPackages();
		bool IsPackageInstalled(PackageReference p);
		void UninstallPackage(PackageReference p);
		void InstallPackage(PackageRequest p);
	}
}
