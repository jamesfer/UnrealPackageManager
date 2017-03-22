using Ninject;

namespace UnrealPackageManager
{
	interface IVerb
	{
		// Executes this verb
		void Execute(IKernel kernel);
	}
}
