using System;
using CommandLine;
using Ninject;
using UnrealPackageManager.DI;

namespace UnrealPackageManager.Commands
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
				IKernel kernel = UPMKernel.Make();
				verb.Execute(kernel);
			}
			else
			{
				Console.WriteLine("Console command matched a verb that was not the right class");
			}
		}
	}
}
