using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnrealPackageManager.FileSystem;
using Ninject;

namespace UnrealPackageManager
{
	class Project
	{
		protected IDirectory rootDir;
		protected Registry registry;

		
		public Registry LocalRegistry
		{
			get
			{
				return registry;
			}
		}


		public Project([Named("Root")] IDirectory rootDir, Registry registry)
		{
			this.rootDir = rootDir;
			this.registry = registry;
		}

		
		//protected IDirectory FindSourceDirectory()
		//{
		//	IDirectory sourceDir = rootDir.FindDirectory("Source");
		//	if (sourceDir != null)
		//	{
		//		return sourceDir;
		//	}

		//	throw new DirectoryNotFoundException(rootDir, "Source");
		//}


		//public Registry.Registry GetRegistry()
		//{
		//	if (registry == null)
		//	{
		//		registry = new Registry.Registry(FindSourceDirectory());
		//	}

		//	return registry;
		//}
	}
}
