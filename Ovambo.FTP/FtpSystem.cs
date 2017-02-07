using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FubarDev.FtpServer.FileSystem;
using Ovambo.API;

namespace Ovambo.FTP
{
	public class FtpSystem : IUnixFileSystem
	{
		private readonly IFileSystem sys;

		public FtpSystem(IFileSystem sys)
		{
			this.sys = sys;
		}

		public IUnixDirectoryEntry Root {
			get {
				return new FtpDirectory(this, sys.Root);
			}
		}
		
		public Task<IReadOnlyList<IUnixFileSystemEntry>> GetEntriesAsync(IUnixDirectoryEntry dir, CancellationToken token)
		{
			return Task.Run(() => GetEntries((FtpDirectory)dir));
		}

		private IReadOnlyList<IUnixFileSystemEntry> GetEntries(FtpDirectory dir)
		{
			return dir.Items.ToList().AsReadOnly();
		}
		
		public Task<IUnixFileSystemEntry> GetEntryByNameAsync(IUnixDirectoryEntry dir, string name, CancellationToken cancellationToken)
		{
			return Task.Run(() => GetEntryByName((FtpDirectory)dir, name));
		}
		
		private IUnixFileSystemEntry GetEntryByName(FtpDirectory dir, string name)
		{
			return dir.Items.FirstOrDefault(i => i.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));
		}
		
		public StringComparer FileSystemEntryComparer { get { return StringComparer.InvariantCultureIgnoreCase; } }
		
		#region Crap
		public Task<IUnixFileSystemEntry> MoveAsync(IUnixDirectoryEntry parent, IUnixFileSystemEntry source, IUnixDirectoryEntry target, string fileName, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		public Task UnlinkAsync(IUnixFileSystemEntry entry, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		public Task<IUnixDirectoryEntry> CreateDirectoryAsync(IUnixDirectoryEntry targetDirectory, string directoryName, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		public Task<Stream> OpenReadAsync(IUnixFileEntry file, long start, CancellationToken cancellationToken)
		{
			return Task.Run(() => OpenRead((FtpFile)file, start));
		}
		
		private Stream OpenRead(FtpFile file, long start)
		{
			return file.Read(start);
		}

		public Task<IBackgroundTransfer> AppendAsync(IUnixFileEntry fileEntry, long? startPosition, Stream data, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		public Task<IBackgroundTransfer> CreateAsync(IUnixDirectoryEntry targetDirectory, string fileName, Stream data, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		public Task<IBackgroundTransfer> ReplaceAsync(IUnixFileEntry fileEntry, Stream data, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		public Task<IUnixFileSystemEntry> SetMacTimeAsync(IUnixFileSystemEntry entry, DateTimeOffset? modify, DateTimeOffset? access, DateTimeOffset? create, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		public bool SupportsAppend {
			get {
				throw new NotImplementedException();
			}
		}

		public bool SupportsNonEmptyDirectoryDelete {
			get {
				throw new NotImplementedException();
			}
		}

		public void Dispose()
		{
		}
		#endregion
	}
}