using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Linq;
using NWebDav.Server;
using NWebDav.Server.Http;
using NWebDav.Server.Props;
using NWebDav.Server.Stores;

namespace Ovambo.WebDAV
{
	public class DavPropManager : IPropertyManager
	{
		public Task<object> GetPropertyAsync(IHttpContext context, IStoreItem item, XName propertyName, bool skipExpensive = false)
		{
			throw new NotImplementedException();
		}
		
		public Task<DavStatusCode> SetPropertyAsync(IHttpContext context, IStoreItem item, XName propertyName, object value)
		{
			throw new NotImplementedException();
		}
		
		public IList<PropertyInfo> Properties {
			get {
				return new [] { new PropertyInfo() };
			}
		}
	}
}