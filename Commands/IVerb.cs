using Ninject;

namespace UnrealPackageManager.Commands
{
	interface IVerb
	{
		// Executes this verb
		void Execute(IKernel kernel);
	}
}
