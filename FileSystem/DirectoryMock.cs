using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnrealPackageManager.FileSystem
{
	class DirectoryMock : DirectoryBase
	{
		public List<IFileSystemItem> items;

		public DirectoryMock(string name, string path, List<IFileSystemItem> items = null)
		{
			this.name = name;
			this.path = path;

			if (items != null)
			{
				this.items = items;
			}
			else
			{
				this.items = new List<IFileSystemItem>();
			}
		}

		public override IDirectory CreateDirectory(string childName)
		{
			if (FindDirectory(childName) != null)
			{
				// Replace with custom exception
				throw new Exception("Directory already exists");
			}

			DirectoryMock child = new DirectoryMock(childName, path + "/" + childName);
			items.Add(child);
			return child;
		}

		public override List<IFileSystemItem> GetItems()
		{
			return items;
		}
	}
}
