using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnrealPackageManager.FileSystem
{
	abstract class DirectoryBase : FileSystemItemBase, IDirectory
	{
		public abstract List<IFileSystemItem> GetItems();
		public abstract IDirectory CreateDirectory(string name);

		public List<IDirectory> GetDirectories()
		{
			List<IDirectory> dirs = new List<IDirectory>();
			foreach (IFileSystemItem item in GetItems())
			{
				if (item is IDirectory)
				{
					dirs.Add(item as IDirectory);
				}
			}
			return dirs;
		}


		public IDirectory FindDirectory(string name)
		{
			foreach (IDirectory dir in GetDirectories())
			{
				if (dir.Name == name)
				{
					return dir;
				}
			}

			return null;
		}


		public List<IFile> GetFiles()
		{
			List<IFile> files = new List<IFile>();
			foreach (IFileSystemItem item in GetItems())
			{
				if (item is IFile)
				{
					files.Add(item as IFile);
				}
			}
			return files;
		}
	}
}
