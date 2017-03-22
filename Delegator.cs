using System;
using CommandLine;
using Ninject;

namespace UnrealPackageManager
{
	class Delegator<T> where T : new()
	{
		public static void parse(string[] args)
		{
			T verbs = new T();
			bool result = Parser.Default.ParseArguments(args, verbs, execute);
			if (!result)
			{
				Console.WriteLine("Error");
			}
		}


		protected static void execute(string name, object options)
		{
			IVerb verb = options as IVerb;
			if (verb != null)
			{
				IKernel kernel = new StandardKernel();
				verb.Execute(kernel);
			}
			else
			{
				Console.WriteLine("Console command matched a verb that was not the right class");
			}
		}
	}
}
