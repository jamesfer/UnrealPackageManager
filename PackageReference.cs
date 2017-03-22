using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnrealPackageManager
{
	public enum PackageSource {
		Github,
		Bitbucket
	}

	public class PackageReference
	{
		public string Owner;
		public string Name;
		public PackageSource Source;

		public PackageReference(string owner, string name, PackageSource source)
		{
			Owner = owner;
			Name = name;
			Source = source;
		}

		// TODO move this out of the package class
		public string Address
		{
			get
			{
				StringBuilder builder = new StringBuilder();
				builder.Append("https://");
				
				switch (Source)
				{
					case PackageSource.Github:
						builder.Append("github.com/");
						break;
					case PackageSource.Bitbucket:
						builder.Append("bitbucket.org/");
						break;
                }

				builder.Append(Owner);
				builder.Append("/");
				builder.Append(Name);
				builder.Append(".git");

				return builder.ToString();
			}
		}
	}
}
