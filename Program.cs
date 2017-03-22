namespace UnrealPackageManager
{
	interface IWeapon
	{

	}

	class Sword : IWeapon
	{

	}

	class Program
	{
		static void Main(string[] args)
		{

			Delegator<Verbs>.parse(args);
		}
	}
}
