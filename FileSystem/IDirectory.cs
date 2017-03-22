using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnrealPackageManager.FileSystem
{
	interface IDirectory : IFileSystemItem
	{
		List<IFileSystemItem> GetItems();
		List<IDirectory> GetDirectories();
		IDirectory FindDirectory(string name);
		List<IFile> GetFiles();
		IDirectory CreateDirectory(string name);
	}
}
