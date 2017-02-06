using System;
using FubarDev.FtpServer;
using FubarDev.FtpServer.FileSystem;
using Ovambo.API;

namespace Ovambo.FTP
{
	public class FtpPermissions : IUnixPermissions
	{

		public IAccessMode User {
			get {
				return new FtpAccess();
			}
		}
		
		public IAccessMode Group {
			get {
				return new FtpAccess();
			}
		}
		
		public IAccessMode Other {
			get {
				return new FtpAccess();
			}
		}
	}
	
	public class FtpAccess : IAccessMode
	{
		public FtpAccess()
		{
			Read = true;
			Write = true;
			Execute = true;
		}
		
		public bool Read { get; set; }
		public bool Write { get; set; }
		public bool Execute { get; set; }
	}
}