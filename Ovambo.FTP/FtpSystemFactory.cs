using System;
using System.Threading.Tasks;
using FubarDev.FtpServer.FileSystem;
using Ovambo.API;

namespace Ovambo.FTP
{
	public class FtpSystemFactory : IFileSystemClassFactory
	{
		private readonly Func<IUnixFileSystem> func;
		
		public FtpSystemFactory(Func<IUnixFileSystem> func)
		{
			this.func = func;
		}
		
		public Task<IUnixFileSystem> Create(string userId, bool isAnonymous)
		{
			return Task.Run(() => CreateSystem());
		}
		
		private IUnixFileSystem CreateSystem()
		{
			return func();
		}
	}
}