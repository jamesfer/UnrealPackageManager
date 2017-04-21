using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnrealPackageManager.PackageManagement
{
	interface IRegistry
	{
		PackageRepository FindPackage(PackageReference p);
		bool HasPackage(PackageReference p);
		void RemovePackage(PackageReference p);
	}
}
