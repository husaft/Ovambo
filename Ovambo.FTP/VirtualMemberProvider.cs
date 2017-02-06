using System;
using FubarDev.FtpServer.AccountManagement;

namespace Ovambo.FTP
{
	public class VirtualMemberProvider : IMembershipProvider
	{
		public MemberValidationResult ValidateUser(string username, string password)
		{
			var stat = MemberValidationStatus.Anonymous;
			var usr = new AnonymousFtpUser(password);
			return usr == null ? new MemberValidationResult(stat)
				: new MemberValidationResult(stat, usr);
		}
	}
}