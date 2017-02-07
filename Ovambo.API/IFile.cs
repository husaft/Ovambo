using System;
using System.IO;

namespace Ovambo.API
{
	public interface IFile : IEntry
	{
		long? Size {
			get;
		}
		
		Stream Content {
			get;
		}
	}
}