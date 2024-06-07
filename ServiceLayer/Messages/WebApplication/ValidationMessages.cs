using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Messages.WebApplication
{
	public static class ValidationMessages
	{
		public static string NulEmptyMessage(string propName)
		{
			return $"{propName} must have a value!";
		}

		public static string MaximumCharacterAllowance(string propName, int restriction)
		{
			return $"{propName} can have maximum {restriction} characters!";
		}

		public static string GreaterThenMessage(string propName, int restriction)
		{
			return $"{propName} must be greater then {restriction}";
		}

		public static string LessThenMessage(string propName, int limit)
		{
			return $"{propName} must be less then {limit}";
		}
	}
}
