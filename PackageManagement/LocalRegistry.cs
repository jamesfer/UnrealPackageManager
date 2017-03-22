using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnrealPackageManager.FileSystem;
using Ninject;
using LibGit2Sharp;

namespace UnrealPackageManager.PackageManagement
{
	class LocalRegistry : IRegistry
	{
		protected PackageResolver resolver;
		protected IDirectory sourceDir;
		protected List<PackageRepository> repositories;

		protected List<PackageRepository> Repositories
		{
			get
			{
				if (repositories == null)
				{
					repositories = LoadRepositories();
				}

				return repositories;
			}
		}


		public LocalRegistry([Named("Source")] IDirectory sourceDir, PackageResolver resolver)
		{
			this.resolver = resolver;
			this.sourceDir = sourceDir;
		}


		public PackageRepository FindPackage(PackageReference p)
		{
			foreach (PackageRepository existingPackage in Repositories)
			{
				if (existingPackage.Reference.Equals(p))
				{
					return existingPackage;
				}
			}

			return null;
		}


		public bool HasPackage(PackageReference p)
		{
			return FindPackage(p) != null;
		}


		//public IEnumerable<PackageReference> GetAllPackages()
		//{
		//	List<PackageReference> packages = new List<PackageReference>();

		//	List<IDirectory> dirs = sourceDir.GetDirectories();
		//	foreach (IDirectory dir in dirs)
		//	{
		//		if (Repository.IsValid(dir.Path))
		//		{
		//			Repository repo = new Repository(dir.Path);
		//			packages.Add(new PackageReference("", dir.Name, PackageSource.Github));
		//		}
		//	}

		//	return packages;
		//}


		public void AddPackage(PackageRequest request)
		{
			IDirectory destination = sourceDir.FindDirectory(request.RequestedPackage.Name);
			if (destination == null)
			{
				destination = sourceDir.CreateDirectory(request.RequestedPackage.Name);
			}

			Repository.Clone(request.CloneUrl, destination.Path);		
		}


		public void RemovePackage(PackageReference p)
		{
			throw new NotImplementedException();
		}


		private List<PackageRepository> LoadRepositories()
		{
			List<PackageRepository> repos = new List<PackageRepository>();

			foreach (IDirectory packageDir in sourceDir.GetDirectories())
			{
				if (Repository.IsValid(packageDir.Path))
				{
					repos.Add(LoadFromDirectory(packageDir));
				}
			}

			return repos;
		}

		
		private PackageRepository LoadFromDirectory(IDirectory dir)
		{
			PackageReference reference = null;

			Repository repo = new Repository(dir.Path);
			foreach (Remote remote in repo.Network.Remotes)
			{
				if (remote.Name == "origin")
				{
					PackageRequest req = resolver.ResolvePackageReference(remote.Url);
					reference = req.RequestedPackage;
					break;	
				}
			}

			if (reference != null)
			{
				return new PackageRepository(dir, reference);
			}

			// TODO change type of exception
			throw new ArgumentException("The directory did not point to a valid repository");
		}
	}
}
