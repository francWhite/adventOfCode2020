namespace Day_04.ValidationRules
{
	internal class IyrValidator : IValidatorRule
	{
		public bool IsResponsible(string field)
		{
			return field == "iyr";
		}

		public bool IsValid(string value)
		{
			int.TryParse(value, out var year);
			return year >= 2010 && year <= 2020;
		}
	}
}