using Ninject;

namespace UnrealPackageManager.DI
{
	static class UPMKernel
	{
		public static IKernel Make()
		{
			return new StandardKernel(new MainModule());
		}
	}
}
