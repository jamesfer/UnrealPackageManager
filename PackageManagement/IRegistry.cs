using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnrealPackageManager.PackageManagement
{
	interface IRegistry
	{
		//IEnumerable<PackageRepository> GetAllPackages();
		PackageRepository FindPackage(PackageReference p);
		bool HasPackage(PackageReference p);
		void AddPackage(PackageRequest p);
		void RemovePackage(PackageReference p);
	}
}
