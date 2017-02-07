using System;
using System.IO;
using System.Linq;
using System.Text;
using Ovambo.API;

namespace Ovambo.Common
{
	public class FuncFile : AbstractEntry, IFile
	{
		private readonly Func<byte[]> reader;

		public FuncFile(Func<string> texter)
		{
			this.reader = () => Encoding.UTF8.GetBytes(texter());
		}
		
		public FuncFile(Func<byte[]> reader = null)
		{
			this.reader = reader ?? (() => new byte[0]);
		}

		public long? Size {
			get { return reader().LongLength; }
		}

		public Stream Content {
			get { return new MemoryStream(reader()); }
		}
		
		public override bool IsFolder { get { return false; } }
	}
}