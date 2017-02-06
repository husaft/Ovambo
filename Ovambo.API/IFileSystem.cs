using System;

namespace Ovambo.API
{
	public interface IFileSystem
	{
		IDirectory Root { get; }
	}
}