using System;
using System.Linq;
using Ovambo.API;

namespace Ovambo.Common
{
	public class FuncFileSystem : IFileSystem
	{
		private readonly Func<IDirectory> folder;

		public FuncFileSystem(IDirectory folder)
		{
			this.folder = () => folder;
		}
		
		public FuncFileSystem(Func<IDirectory> folder = null)
		{
			this.folder = folder ?? (() => new FuncDirectory { Name = "EmptyRoot" });
		}
		
		public IDirectory Root { get { return folder(); } }
	}
}