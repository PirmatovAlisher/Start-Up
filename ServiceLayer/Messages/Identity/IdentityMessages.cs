using System.Security.Policy;

namespace ServiceLayer.Messages.Identity
{
	public static class IdentityMessages
	{
		public static string CheckEmailAddress()
		{
			return "Input should be in an Email format";
		}

		public static string ComparePassword()
		{
			return "Confirm Password must match with Password";
		}

		public const string SecurityStampError = "Your critical information has been changed, please try to log in again.";

	}
}
