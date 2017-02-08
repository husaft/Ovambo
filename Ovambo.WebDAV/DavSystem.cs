using System;
using System.Threading.Tasks;
using NWebDav.Server.Http;
using Ovambo.API;
using NWebDav.Server.Stores;

namespace Ovambo.WebDAV
{
	public class DavSystem : IStore
	{
		private readonly IFileSystem sys;
		
		public DavSystem(IFileSystem sys)
		{
			this.sys = sys;
		}

		public Task<IStoreItem> GetItemAsync(Uri uri, IHttpContext context)
		{
			throw new NotImplementedException();
		}
		
		public Task<IStoreCollection> GetCollectionAsync(Uri uri, IHttpContext context)
		{
			return Task.Run(() => GetCollection(uri, context));
		}
		
		private IStoreCollection GetCollection(Uri uri, IHttpContext context)
		{
			return new DavDirectory(null, sys.Root);
		}
	}
}