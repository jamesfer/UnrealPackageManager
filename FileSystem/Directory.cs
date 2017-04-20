using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnrealPackageManager.FileSystem
{
	class Directory : DirectoryBase
	{
		public Directory(string name, IDirectory parent) : base(name, parent)
		{

		}


		//public abstract List<IFileSystemItem> GetItems()
		//{

		//}

		//public abstract IDirectory CreateDirectory(string name)
		//{

		//}
	}
}
