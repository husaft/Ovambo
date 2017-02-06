using System;

namespace Ovambo.API
{
	public interface IFile : IEntry
	{
		long? Size {
			get;
		}
	}
}