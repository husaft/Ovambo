using System;
using System.Collections.Generic;
using System.Linq;
using Ovambo.API;

namespace Ovambo.Common
{
	public class FuncDirectory : AbstractEntry, IDirectory
	{
		private readonly Func<IEnumerable<IEntry>> entries;

		public FuncDirectory(Func<IEnumerable<IEntry>> entries = null)
		{
			this.entries = entries ?? (() => Enumerable.Empty<IEntry>());
		}

		public IEnumerable<IEntry> Items { get { return entries(); } }

		public override bool IsFolder { get { return true; } }
	}
}