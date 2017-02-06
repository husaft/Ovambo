using System;
using System.Linq;
using System.Collections.Generic;
using FubarDev.FtpServer.FileSystem;
using Ovambo.API;

namespace Ovambo.FTP
{
	public class FtpDirectory : FtpEntry, IUnixDirectoryEntry
	{
		private readonly IDirectory dir;

		public FtpDirectory(IUnixFileSystem sys, IDirectory dir) : base(sys, dir)
		{
			this.dir = dir;
		}
		
		internal IEnumerable<IUnixFileSystemEntry> Items {
			get {
				foreach (var item in dir.Items)
				{
					var myDir = item as IDirectory;
					if (myDir != null)
						yield return new FtpDirectory(sys, myDir);
					var myFile = item as IFile;
					if (myFile != null)
						yield return new FtpFile(sys, myFile);
				}
			}
		}

		public bool IsRoot {
			get { return dir == null; }
		}

		public bool IsDeletable {
			get { return false; }
		}
	}
}