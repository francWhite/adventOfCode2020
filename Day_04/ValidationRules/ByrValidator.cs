namespace Day_04.ValidationRules
{
	internal class ByrValidator : IValidatorRule
	{
		public bool IsResponsible(string field)
		{
			return field == "byr";
		}

		public bool IsValid(string value)
		{
			int.TryParse(value, out var year);
			return year >= 1920 && year <= 2002;
		}
	}
}