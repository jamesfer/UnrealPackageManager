using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnrealPackageManager.PackageManagement
{
	class FakedPackageRegistry : ILocalPackageRegistry
	{
		List<PackageReference> localPackages;

		public FakedPackageRegistry()
		{
			localPackages = new List<PackageReference>();
		}

		public List<PackageReference> GetPackages()
		{
			return localPackages;
		}

		public void InstallPackage(PackageRequest p)
		{
			localPackages.Add(p.RequestedPackage);
		}

		public bool IsPackageInstalled(PackageReference p)
		{
			return localPackages.Contains(p);
		}

		public void UninstallPackage(PackageReference p)
		{
			localPackages.Remove(p);
		}
	}
}
