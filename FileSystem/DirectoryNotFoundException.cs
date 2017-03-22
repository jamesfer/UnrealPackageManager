using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnrealPackageManager.FileSystem
{
	class DirectoryNotFoundException : UPMException
	{
		public DirectoryNotFoundException(IDirectory currentDir, string subDirName) : base(createMessageString(currentDir, subDirName))
		{

		}

		public DirectoryNotFoundException() : base("Could not find a directory.")
		{

		}

		public DirectoryNotFoundException(string message) : base(message)
		{

		}

		public DirectoryNotFoundException(string message, Exception inner) : base(message, inner)
		{

		}

		public static string createMessageString(IDirectory currentDir, string subDirName)
		{
			return string.Format("Could not find a directory named {1} in {0}.", currentDir.Path, subDirName);
		}
	}
}
