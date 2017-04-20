using System;

namespace UnrealPackageManager.FileSystem
{
	abstract class FileSystemItemBase : IFileSystemItem
	{
		protected string name;
		protected IDirectory parent;


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
				return System.IO.Path.Combine(parent.Path, Name);
			}
		}

		public IDirectory Parent
		{
			get
			{
				return parent;
			}
		}


		public FileSystemItemBase(string name, IDirectory parent)
		{
			this.name = name;
			this.parent = parent;
		}
	}
}
