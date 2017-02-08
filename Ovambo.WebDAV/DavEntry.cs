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

		public virtual string FullPath {
			get {
				var par = parent == null ? "" : parent.Name;
				return string.Format("{0}/{1}", par, Name);
			}
		}
		
		public virtual string Name {
			get { return entry.Name; }
		}
		
		public virtual string UniqueKey {
			get { return FullPath; }
		}
		
		public virtual bool IsWritable {
			get {
				throw new NotImplementedException();
			}
		}

		public virtual Task<Stream> GetReadableStreamAsync(IHttpContext context)
		{
			throw new NotImplementedException();
		}
		
		public virtual Task<DavStatusCode> UploadFromStreamAsync(IHttpContext context, Stream source)
		{
			throw new NotImplementedException();
		}
		
		public virtual Task<StoreItemResult> CopyAsync(IStoreCollection destination, string name, bool overwrite, IHttpContext context)
		{
			throw new NotImplementedException();
		}
		
		public virtual IPropertyManager PropertyManager {
			get { return new DavPropManager(); }
		}
		
		public virtual ILockingManager LockingManager {
			get {
				throw new NotImplementedException();
			}
		}
	}
	
	
}