using System.Collections.Generic;

namespace Day_04.ValidationRules
{
	internal class EclValidator : IValidatorRule
	{
		private readonly HashSet<string> _possibleValues = new HashSet<string>
		{
			"amb",
			"blu",
			"brn",
			"gry",
			"grn",
			"hzl",
			"oth"
		};
		
		public bool IsResponsible(string field)
		{
			return field == "ecl";
		}

		public bool IsValid(string value)
		{
			return _possibleValues.Contains(value);
		}
	}
}