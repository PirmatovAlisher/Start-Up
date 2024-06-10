using EntityLayer.Identity.ViewModels;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Helpers.Identity.EmailHelper
{
	public interface IEmailSendMethod
	{
		Task SendResetPasswordLinkWithToken(string toEmail, string passwordResetLink);
	}

	public class EmailSendMethod : IEmailSendMethod
	{

		private readonly GmailInformationVM _emailInformation;

		public EmailSendMethod(IOptions<GmailInformationVM> emailInformation)
		{
			_emailInformation = emailInformation.Value;
		}


		public async Task SendResetPasswordLinkWithToken(string toEmail, string passwordResetLink)
		{

			var smtpClient = new SmtpClient();

			smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
			smtpClient.Host = _emailInformation.Host;
			smtpClient.Port = 587;
			smtpClient.UseDefaultCredentials = false;
			smtpClient.Credentials = new NetworkCredential(_emailInformation.Email, _emailInformation.Password);
			smtpClient.EnableSsl = true;


			var mailMessage = new MailMessage();

			mailMessage.From = new MailAddress(_emailInformation.Email);
			mailMessage.To.Add(toEmail);
			mailMessage.Subject = "LocalHost | Password Reset Link";
			mailMessage.Body = $@"<h4>Click on the link to reset Password</h4>
									<p><a href='{passwordResetLink}'>Reset Password</a> </p>";
			mailMessage.IsBodyHtml = true;

			await smtpClient.SendMailAsync(mailMessage);
		}
	}
}
