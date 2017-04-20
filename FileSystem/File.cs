using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnrealPackageManager.FileSystem
{
	class File : FileSystemItemBase, IFile
	{
		public File(string name, IDirectory parent) : base(name, parent)
		{
			
		}
	}
}
