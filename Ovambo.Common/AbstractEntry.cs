using System;
using Ovambo.API;

namespace Ovambo.Common
{
	public abstract class AbstractEntry : IEntry
	{
		public DateTime? CreationDate {
			get;
			set;
		}

		public DateTime? ModificationDate {
			get;
			set;
		}

		public string Name {
			get;
			set;
		}

		public abstract bool IsFolder {
			get;
		}
	}
}