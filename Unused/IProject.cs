using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnrealPackageManager
{
	interface IProject
	{
		Registry GetRegistry();
	}
}
