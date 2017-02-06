using System;
using System.Net;
using System.Reflection;
using FubarDev.FtpServer;
using FubarDev.FtpServer.FileSystem;
using Ovambo.API;
using Ovambo.FTP;
using Server = FubarDev.FtpServer.FtpServer;

namespace Ovambo.FTP
{
	public class FtpServer : INetServer
	{
		private readonly Server server;

		public FtpServer(IFileSystem sys, string host = "127.0.0.1", int port = 21)
		{
			var fsp = new FtpSystemFactory(() => new FtpSystem(sys));
			var msp = new VirtualMemberProvider();
			var ass = typeof(Server).Assembly;
			var cmd = new AssemblyFtpCommandHandlerFactory(ass, new Assembly[0]);
			server = new Server(fsp, msp, host, port, cmd);
			server.Start();
		}

		public IPEndPoint Endpoint {
			get {
				var addr = IPAddress.Parse(server.ServerAddress);
				return new IPEndPoint(addr, server.Port);
			}
		}
		
		public void Dispose()
		{
			server.Stop();
			server.Dispose();
		}
	}
}