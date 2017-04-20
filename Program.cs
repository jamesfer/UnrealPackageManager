using UnrealPackageManager.Commands;

namespace UnrealPackageManager
{
	class Program
	{
		static void Main(string[] args)
		{
			Delegator<Verbs>.parse(args);
		}
	}
}
