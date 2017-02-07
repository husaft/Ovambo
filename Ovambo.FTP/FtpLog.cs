using System;
using Common.Logging;
using FubarDev.FtpServer;

namespace Ovambo.FTP
{
	public class FtpLog : IFtpLog
	{
		private readonly ILog log;

		public FtpLog(ILog log)
		{
			this.log = log;
		}

		public void Trace(string format, params object[] args)
		{
			log.TraceFormat(format, args);
		}

		public void Trace(Exception ex, string format, params object[] args)
		{
			log.TraceFormat(format, ex, args);
		}

		public void Debug(string format, params object[] args)
		{
			log.DebugFormat(format, args);
		}

		public void Debug(Exception ex, string format, params object[] args)
		{
			log.DebugFormat(format, ex, args);
		}

		public void Info(string format, params object[] args)
		{
			log.InfoFormat(format, args);
		}

		public void Info(Exception ex, string format, params object[] args)
		{
			log.InfoFormat(format, ex, args);
		}

		public void Warn(string format, params object[] args)
		{
			log.WarnFormat(format, args);
		}

		public void Warn(Exception ex, string format, params object[] args)
		{
			log.WarnFormat(format, ex, args);
		}

		public void Error(string format, params object[] args)
		{
			log.ErrorFormat(format, args);
		}

		public void Error(Exception ex, string format, params object[] args)
		{
			log.ErrorFormat(format, ex, args);
		}

		public void Fatal(string format, params object[] args)
		{
			log.FatalFormat(format, args);
		}

		public void Fatal(Exception ex, string format, params object[] args)
		{
			log.FatalFormat(format, ex, args);
		}
	}
}