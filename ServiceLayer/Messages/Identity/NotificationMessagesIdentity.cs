using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Messages.Identity
{
	public static class NotificationMessagesIdentity
	{
		private const string SignUpSuccess = " has been created";
		public const string LogInSuccess = "You have logged in";
		public const string ResetPasswordSuccess= "Your password reset link has been sent to your email address";
		public const string PasswordChangeSuccess= "Your password has been changed, please try to log in";
		public const string TokenValidationError= "Your token is no more valid, please try again";
		private const string UserEditSuccess= " has been updated";
		private const string UserError= " does not exist";

		public const string SucceededTitle = "Congratulations!";
		public const string FailedTitle = "I am sorry!";

		public static string SignUp(string userName) => userName + SignUpSuccess;
		public static string UserEdit(string userName) => userName + UserEditSuccess;
		public static string UserNotFound(string userName) => userName + UserError;
	}
}
