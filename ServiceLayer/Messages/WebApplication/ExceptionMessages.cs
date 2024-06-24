using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Messages.WebApplication
{
	public static class ExceptionMessages
	{
		public const string ConcurrencyException = "Your data has been changed, please try later.";
	}
}
