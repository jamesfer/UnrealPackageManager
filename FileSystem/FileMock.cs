using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnrealPackageManager.FileSystem
{
	class FileMock : FileSystemItemBase, IFile
	{
		string contents;


		public FileMock(string name, IDirectory parent, string contents) : base(name, parent)
		{
			this.contents = contents;
		}
	}
}
