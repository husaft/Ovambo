using System;
using System.Net;

namespace Ovambo.API
{
	public interface INetServer : IDisposable
	{
		IPEndPoint Endpoint { get; }
	}
}