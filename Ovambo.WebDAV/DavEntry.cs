using System;
using System.IO;
using System.Threading.Tasks;
using NWebDav.Server;
using NWebDav.Server.Http;
using NWebDav.Server.Locking;
using NWebDav.Server.Props;
using Ovambo.API;
using NWebDav.Server.Stores;

namespace Ovambo.WebDAV
{
	public abstract class DavEntry : IStoreItem, IDiskStoreItem
	{
		protected readonly IStoreCollection parent;
		private readonly IEntry entry;
		
		protected DavEntry(IStoreCollection parent, IEntry entry)
		{
			this.parent = parent;
			this.entry = entry;
		}

		public string Name {
			get {
				throw new NotImplementedException();
			}
		}
		
		public bool IsWritable { get; set; }
		
		public string FullPath {
			get {
				throw new NotImplementedException();
			}
		}
		
		public string UniqueKey {
			get {
				throw new NotImplementedException();
			}
		}
		
		public IPropertyManager PropertyManager {
			get {
				throw new NotImplementedException();
			}
		}
		
		public ILockingManager LockingManager {
			get {
				throw new NotImplementedException();
			}
		}
		
		public abstract Task<Stream> GetReadableStreamAsync(IHttpContext context);
		
		public abstract Task<DavStatusCode> UploadFromStreamAsync(IHttpContext context, Stream source);
		
		public abstract Task<StoreItemResult> CopyAsync(IStoreCollection destination, string name, bool overwrite, IHttpContext context);
	}
}