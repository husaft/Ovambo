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
			return Task.Run(() => Get<IStoreItem>(uri, context));
		}
		
		public Task<IStoreCollection> GetCollectionAsync(Uri uri, IHttpContext context)
		{
			return Task.Run(() => Get<IStoreCollection>(uri, context));
		}
		
		private T Get<T>(Uri uri, IHttpContext context) where T : class, IStoreItem
		{
			return new DavDirectory(null, sys.Root) as T;
		}
	}
}