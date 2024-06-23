using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Messages.WebApplication
{
	public static class NotificationMessagesWebApplication
	{
		private const string BaseAddMessage = "Has been submitted!";
		private const string BaseUpdateMessage = "Has been updated!";
		private const string BaseDeleteMessage = "Has been deleted!";

		public const string SucceededTitle = "Congratulations!";
		public const string FailedTitle = "I am sorry!";

		public static string AddMessage(string subject) => subject + BaseAddMessage;
		public static string UpdateMessage(string subject) => subject + BaseUpdateMessage;
		public static string DeleteMessage(string subject) => subject + BaseDeleteMessage;
	}
}
