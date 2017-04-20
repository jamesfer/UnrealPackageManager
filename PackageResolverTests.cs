using System;
using Xunit;
using Xunit.Abstractions;
using UnrealPackageManager.TestUtils;

namespace UnrealPackageManager
{
	public class TestPackageResolver
	{
		private readonly ITestOutputHelper output;
		PackageResolver resolver = new PackageResolver();

		public static string[] References = new string[]
		{
			"https://github.com/username/repo",
			"http://bitbucket.org/user-name7/repo-2",
			"https://bitbucket.org/user-name/repo-two.git",
			"git@github.com/username/repo",
			"git@bitbucket.org/user-name7/repo-2",
			"git@bitbucket.org/user-name/repo-two.git",
			"github/username/repo",
			"bitbucket/user-name7/repo-2",
			"bitbucket/user-name/repo-two.git"
		};

		public static string[] Owners =
		{
			"username",
			"user-name7",
			"user-name",
			"username",
			"user-name7",
			"user-name",
			"username",
			"user-name7",
			"user-name"
		};

		public static string[] Names =
		{
			"repo",
			"repo-2",
			"repo-two",
			"repo",
			"repo-2",
			"repo-two",
			"repo",
			"repo-2",
			"repo-two",
		};

		public static Enum[] Sources =
		{
			PackageSource.Github,
			PackageSource.Bitbucket,
			PackageSource.Bitbucket,
			PackageSource.Github,
			PackageSource.Bitbucket,
			PackageSource.Bitbucket,
			PackageSource.Github,
			PackageSource.Bitbucket,
			PackageSource.Bitbucket,
		};

		public static Enum[] Methods =
		{
			PackageRequestMethod.HTTP,
			PackageRequestMethod.HTTP,
			PackageRequestMethod.HTTP,
			PackageRequestMethod.SSH,
			PackageRequestMethod.SSH,
			PackageRequestMethod.SSH
		};


		public TestPackageResolver(ITestOutputHelper helper)
		{
			output = helper;
		}


		[Theory]
		[MultiMemberData("References", "Owners")]
		public void CanIdentifyOwner(string reference, string owner)
		{
			string result = resolver.ResolvePackageReference(reference).RequestedPackage.Owner;
            Assert.StrictEqual(owner, result);
        }

		[Theory]
		[MultiMemberData("References", "Names")]
		public void CanIdentifyName(string reference, string name)
		{
			string result = resolver.ResolvePackageReference(reference).RequestedPackage.Name;
			Assert.StrictEqual(name, result);
		}

		[Theory]
		[MultiMemberData("References", "Sources")]
		public void CanIdentifySource(string reference, PackageSource source)
		{
			PackageSource result = resolver.ResolvePackageReference(reference).RequestedPackage.Source;
			Assert.StrictEqual(source, result);
		}

		[Theory]
		[MultiMemberData("References", "Methods")]
		public void CanIdentifyMethod(string reference, PackageRequestMethod method)
		{
			PackageRequestMethod result = resolver.ResolvePackageReference(reference).Method;
			Assert.StrictEqual(method, result);
		}

		[Fact]
		public void ThrowsExceptionOnMalformedReference()
		{
			string reference = "/username/";
			Assert.Throws<PackageReferenceParseException>(() => {
				resolver.ResolvePackageReference(reference);
				});
		}
	}
}
