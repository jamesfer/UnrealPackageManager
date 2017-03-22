using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnrealPackageManager
{
	public enum PackageRequestMethod
	{
		HTTP,
		SSH
	}

	public class PackageRequest
	{
		public PackageReference RequestedPackage;
		public PackageRequestMethod Method;

		public string CloneUrl
		{
			get
			{
				return BuildCloneUrl();
			}
		}

		public PackageRequest(PackageReference package, PackageRequestMethod method)
		{
			RequestedPackage = package;
			Method = method;
		}

		private string BuildCloneUrl()
		{
			StringBuilder builder = new StringBuilder();
			string delimiter = "";

			switch (Method)
			{
				case PackageRequestMethod.HTTP:
					builder.Append("https://");
					delimiter = "/";
					break;
				case PackageRequestMethod.SSH:
					builder.Append("git@");
					delimiter = ":";
					break;
			}

			switch (RequestedPackage.Source)
			{
				case PackageSource.Github:
					builder.Append("github.com");
					break;
				case PackageSource.Bitbucket:
					builder.Append("Bitbucket.org");
					break;
			}

			builder.Append(delimiter);
			builder.Append(RequestedPackage.Owner);
			builder.Append("/");
			builder.Append(RequestedPackage.Name);
			builder.Append(".git");
			return builder.ToString();
		}
	}
}
