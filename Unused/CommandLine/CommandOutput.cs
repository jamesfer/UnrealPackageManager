using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace UnrealPackageManager.CommandLine
{
	class CommandOutput
	{
		protected StreamReader stdOut;
		protected StreamReader stdErr;

		public StreamReader StdOut
		{
			get
			{
				return stdOut;
			}
		}

		public StreamReader StdErr
		{
			get
			{
				return stdErr;
			}
		}

		public CommandOutput(StreamReader stdOut, StreamReader stdErr)
		{
			this.stdOut = stdOut;
			this.stdErr = stdErr;
		}
	}
}
