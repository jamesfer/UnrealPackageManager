using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace UnrealPackageManager
{
	class PackageResolver
	{
		public static string PackageRegexString = @"^(?'method'(https?|git))?(:\/\/|@)?(?'source'(github|bitbucket))(\.org|\.com)?[\/:](?'owner'[^\/]*)[\/](?'name'[^.]*)";

		private Regex PackageRegex = new Regex(PackageRegexString);

		// Transforms an abstract package reference into a normalized address
		// Accepted forms:
		//   https://github.com/{UserName||OrgName}/{RepositoryName}.git
		//   git@bitbucket.org:{UserName||OrgName}/{RepositoryName}.git
		//   github/{UserName||OrgName}/{RepositoryName}
		public PackageRequest ResolvePackageReference(string reference)
		{
			Match m = PackageRegex.Match(reference);
			if (m.Value == String.Empty)
			{
				throw new PackageReferenceParseException(reference);
			}

			PackageRequestMethod method = getRequestMethod(m.Groups["method"].Value);
			PackageSource source = getSource(m.Groups["source"].Value);
			string owner = m.Groups["owner"].Value;
			string name = m.Groups["name"].Value;

			return new PackageRequest(new PackageReference(owner, name, source), method);
		}

		private PackageSource getSource(string sourceString)
		{
			sourceString = sourceString.ToLower();
			switch (sourceString)
			{
				case "github":
					return PackageSource.Github;
				case "bitbucket":
					return PackageSource.Bitbucket;
				default:
					// TODO throw exception
					Console.WriteLine("unknown source type");
					return PackageSource.Github;
			}
		}

		private PackageRequestMethod getRequestMethod(string methodString)
		{
			methodString = methodString.ToLower();
			switch (methodString)
			{
				case "http":
				case "https":
					return PackageRequestMethod.HTTP;
				case "git":
					return PackageRequestMethod.SSH;
				default:
					// TODO throw exception
					Console.WriteLine("Using default request method: HTTP");
					return PackageRequestMethod.HTTP;
			}
		}
	}
}
