using System;
using System.IO;
using Ovambo.API;
using NWebDav.Server.Stores;
using System.Threading.Tasks;
using NWebDav.Server.Http;

namespace Ovambo.WebDAV
{
	public class DavFile : DavEntry, IStoreItem, IDiskStoreItem
	{
		private readonly IFile doc;
		
		public DavFile(IStoreCollection parent, IFile doc) : base(parent, doc)
		{
			this.doc = doc;
		}

		public override Task<Stream> GetReadableStreamAsync(IHttpContext context)
		{
			return Task.Run(() => GetReadableStream(context));
		}
		
		private Stream GetReadableStream(IHttpContext context)
		{
			var stream = doc.Content;
			stream.Position = 0;
			return stream;
		}
	}
}