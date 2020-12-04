namespace Day_04.ValidationRules
{
	internal class EyrValidator : IValidatorRule
	{
		public bool IsResponsible(string field)
		{
			return field == "eyr";
		}

		public bool IsValid(string value)
		{
			int.TryParse(value, out var year);
			return year >= 2020 && year <= 2030;
		}
	}
}