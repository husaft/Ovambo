using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NWebDav.Server;
using NWebDav.Server.Http;
using NWebDav.Server.Stores;
using Ovambo.API;

namespace Ovambo.WebDAV
{
	public class DavDirectory : DavEntry, IStoreCollection, IDiskStoreCollection
	{
		private readonly IDirectory coll;
		
		public DavDirectory(IStoreCollection parent, IDirectory coll) : base(parent, coll)
		{
			this.coll = coll;
		}
		
		public Task<IStoreItem> GetItemAsync(string name, IHttpContext context)
		{
			return Task.Run(() => GetItem(name, context));
		}
		
		private IStoreItem GetItem(string name, IHttpContext context)
		{
			var ignore = StringComparison.InvariantCultureIgnoreCase;
			var items = GetItems(context);
			var item = items.FirstOrDefault(i => i.Name.Equals(name, ignore));
			return item;
		}
		
		public Task<IList<IStoreItem>> GetItemsAsync(IHttpContext context)
		{
			return Task.Run(() => {
			                	IList<IStoreItem> items = GetItems(context).ToList();
			                	return items;
			                });
		}
		
		private IEnumerable<IStoreItem> GetItems(IHttpContext context)
		{
			foreach (var item in coll.Items)
			{
				var myDir = item as IDirectory;
				if (myDir != null)
					yield return new DavDirectory(this, myDir);
				var myFile = item as IFile;
				if (myFile != null)
					yield return new DavFile(this, myFile);
			}
		}
		
		public Task<StoreItemResult> CreateItemAsync(string name, bool overwrite, IHttpContext context)
		{
			throw new NotImplementedException();
		}

		public Task<StoreCollectionResult> CreateCollectionAsync(string name, bool overwrite, IHttpContext context)
		{
			throw new NotImplementedException();
		}

		public Task<StoreItemResult> MoveItemAsync(string sourceName, IStoreCollection destination, string destinationName, bool overwrite, IHttpContext context)
		{
			throw new NotImplementedException();
		}

		public Task<DavStatusCode> DeleteItemAsync(string name, IHttpContext context)
		{
			throw new NotImplementedException();
		}

		public InfiniteDepthMode InfiniteDepthMode {
			get {
				throw new NotImplementedException();
			}
		}
	}
}