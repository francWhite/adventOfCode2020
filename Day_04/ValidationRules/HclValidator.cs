using System.Text.RegularExpressions;

namespace Day_04.ValidationRules
{
	internal class HclValidator : IValidatorRule

	{
		public bool IsResponsible(string field)
		{
			return field == "hcl";
		}

		public bool IsValid(string value)
		{
			return Regex.Match(value, @"#[0-9a-f]{6}").Success;
		}
	}
}