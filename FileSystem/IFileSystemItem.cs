namespace UnrealPackageManager.FileSystem
{
	interface IFileSystemItem
	{
		IDirectory Parent
		{
			get;
		}

		string Name
		{
			get;
		}

		string Path
		{
			get;
		}
	}
}
