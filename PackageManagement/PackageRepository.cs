using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnrealPackageManager.FileSystem;

namespace UnrealPackageManager.PackageManagement
{
	class PackageRepository
	{
		protected IDirectory directory;
		protected PackageReference reference;

		public IDirectory Directory
		{
			get
			{
				return directory;
			}
		}

		public PackageReference Reference
		{
			get
			{
				return reference;
			}
		}


		public PackageRepository(IDirectory directory, PackageReference reference)
		{
			this.directory = directory;
			this.reference = reference;
		}
	}
}
