using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Helpers.Identity.EmailHelper
{
	public interface IEmailSendMethod
	{
		Task SendResetPasswordLinkWithToken(string resetToken, string passwordResetLink);
	}

	public class EmailSendMethod : IEmailSendMethod
	{
		public async Task SendResetPasswordLinkWithToken(string resetToken, string passwordResetLink)
		{

		}
	}
}
