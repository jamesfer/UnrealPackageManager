using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnrealPackageManager
{
	class PackageReferenceParseException : UPMException
	{
		public PackageReferenceParseException(string packageRef) : base(createMessage(packageRef))
		{

		}

		public PackageReferenceParseException() : base()
		{

		}

		//public PackageReferenceParseException(string message) : base(message)
		//{

		//}

		public PackageReferenceParseException(string message, Exception inner) : base(message, inner)
		{

		}


		public static string createMessage(string packageRef)
		{
			return string.Format("Could not interpret \"{0}\" as a package reference.", packageRef);
		}
	}
}
