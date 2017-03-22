using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnrealPackageManager
{
	class UPMException : Exception
	{
		public UPMException() : base()
		{

		}

		public UPMException(string message) : base(message)
		{

		}

		public UPMException(string message, Exception inner) : base(message, inner)
		{

		}
	}
}
