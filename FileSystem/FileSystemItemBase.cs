using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnrealPackageManager.FileSystem
{
	abstract class FileSystemItemBase : IFileSystemItem
	{
		protected string name;
		protected string path;

		public string Name
		{
			get
			{
				return name;
			}
		}


		public string Path
		{
			get
			{
				return path;
			}
		}
	}
}
