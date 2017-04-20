using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnrealPackageManager.FileSystem
{
	class RootDirectory : Directory
	{
		string path;

		public RootDirectory(string name, string path) : base(name, null)
		{
			this.path = path;
		}
	}
}
