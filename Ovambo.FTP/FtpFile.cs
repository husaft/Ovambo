using System;
using System.IO;
using FubarDev.FtpServer.FileSystem;
using Ovambo.API;

namespace Ovambo.FTP
{
	public class FtpFile : FtpEntry, IUnixFileEntry
	{
		private readonly IFile file;

		public FtpFile(IUnixFileSystem sys, IFile file) : base(sys, file)
		{
			this.file = file;
		}

		public long Size {
			get {
				return file.Size.GetValueOrDefault();
			}
		}

		public Stream Read(long start)
		{
			var stream = file.Content;
			stream.Position = start;
			return stream;
		}
	}
}