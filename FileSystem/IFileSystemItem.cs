using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnrealPackageManager.FileSystem
{
	interface IFileSystemItem
	{
		string Name
		{
			get;
		}

		string Path
		{
			get;
		}
	}
}
