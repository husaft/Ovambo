using System;

namespace Ovambo.API
{
	public interface IEntry
	{
		DateTime? CreationDate {
			get;
		}

		DateTime? ModificationDate {
			get;
		}

		bool IsFolder {
			get;
		}

		string Name {
			get;
			set;
		}
	}
}