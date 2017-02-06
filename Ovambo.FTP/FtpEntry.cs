using System;
using FubarDev.FtpServer;
using FubarDev.FtpServer.FileSystem;
using Ovambo.API;

namespace Ovambo.FTP
{
	public abstract class FtpEntry : IUnixFileSystemEntry
	{
		protected readonly IUnixFileSystem sys;
		private readonly IEntry entry;

		protected FtpEntry(IUnixFileSystem sys, IEntry entry)
		{
			this.sys = sys;
			this.entry = entry;
		}
		
		public IUnixFileSystem FileSystem {
			get { return sys; }
		}

		public string Name {
			get { return entry.Name; }
		}

		public DateTimeOffset? CreatedTime {
			get {
				return entry.CreationDate.GetValueOrDefault().ToUniversalTime();
			}
		}

		public DateTimeOffset? LastWriteTime {
			get {
				return entry.ModificationDate.GetValueOrDefault().ToUniversalTime();
			}
		}
		
		public IUnixPermissions Permissions {
			get {
				return new FtpPermissions();
			}
		}
		
		public string Owner {
			get {
				return "TodoO";
			}
		}
		
		public string Group {
			get {
				return "TodoG";
			}
		}

		public long NumberOfLinks {
			get {
				return 0;
			}
		}
	}
}