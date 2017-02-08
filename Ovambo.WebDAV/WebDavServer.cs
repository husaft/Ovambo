using System;
using System.Net;
using System.Linq;
using System.Threading;
using NWebDav.Server;
using NWebDav.Server.Http;
using NWebDav.Server.HttpListener;
using Ovambo.API;
using Server = NWebDav.Server.WebDavDispatcher;

namespace Ovambo.WebDAV
{
	public class WebDavServer : INetServer
	{
		private readonly IFileSystem sys;
		private readonly Uri Uri;
		private readonly HttpListener listener;
		
		private CancellationTokenSource token;

		public WebDavServer(IFileSystem sys, string host = "127.0.0.1", int port = 5005)
		{
			this.sys = sys;
			listener = new HttpListener();
			var url = string.Format("http://{0}:{1}/", host, port);
			listener.Prefixes.Add(url);
			Uri = new Uri(url);
			listener.AuthenticationSchemeSelectorDelegate = ChooseAuth;
			listener.Realm = GetType().Name;
			listener.Start();
			Loop();
		}
		
		public void Dispose()
		{
			token.Cancel();
			listener.Stop();
		}
		
		private async void Loop()
		{
			token = new CancellationTokenSource();
			var requestHandlerFactory = new RequestHandlerFactory();
			var store = new DavSystem(sys);
			var webDavDispatcher = new WebDavDispatcher(store, requestHandlerFactory);
			HttpListenerContext context;
			while (!token.IsCancellationRequested && (context = await listener.GetContextAsync().ConfigureAwait(false)) != null)
			{
				IHttpContext httpCtx;
				if (context.Request.IsAuthenticated)
					httpCtx = new HttpBasicContext(context, checkIdentity: CheckAuth);
				else
					httpCtx = new HttpContext(context);
				await webDavDispatcher.DispatchRequestAsync(httpCtx).ConfigureAwait(false);
			}
		}
		
		private bool CheckAuth(HttpListenerBasicIdentity identity)
		{
			return true; // i.Name == webdavUsername && i.Password == webdavPassword
		}
		
		private AuthenticationSchemes ChooseAuth(HttpListenerRequest req)
		{
			var schemes = AuthenticationSchemes.Negotiate;
			schemes |= AuthenticationSchemes.IntegratedWindowsAuthentication;
			schemes |= AuthenticationSchemes.Digest;
			schemes |= AuthenticationSchemes.Basic;
			schemes |= AuthenticationSchemes.Anonymous;
			schemes |= AuthenticationSchemes.Ntlm;
			return schemes;
		}
		
		public IPEndPoint Endpoint {
			get {
				var addr = IPAddress.Parse(Uri.Host);
				return new IPEndPoint(addr, Uri.Port);
			}
		}
	}
}