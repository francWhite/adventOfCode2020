using System.Text.RegularExpressions;

namespace Day_04.ValidationRules
{
	internal class PidValidator : IValidatorRule
	{
		public bool IsResponsible(string field)
		{
			return field == "pid";
		}

		public bool IsValid(string value)
		{
			return Regex.Match(value, @"^[0-9]{9}$").Success;
		}
	}
}