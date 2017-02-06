using System;
using System.Collections.Generic;

namespace Ovambo.API
{
	public interface IDirectory : IEntry
	{
		IEnumerable<IEntry> Items {
			get;
		}
	}
}