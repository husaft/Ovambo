using System;
using Common.Logging;
using FubarDev.FtpServer;

namespace Ovambo.FTP
{
	public class FtpLogManager : IFtpLogManager
	{
		public IFtpLog CreateLog(FtpConnection connection)
		{
			return new FtpLog(LogManager.GetLogger(connection.GetType()));
		}
		
		public IFtpLog CreateLog(string name)
		{
			return new FtpLog(LogManager.GetLogger(name));
		}
		
		public IFtpLog CreateLog(Type type)
		{
			return new FtpLog(LogManager.GetLogger(type));
		}
	}	
}