using System.Text.RegularExpressions;

namespace Day_04.ValidationRules
{
	internal class HgtValidator : IValidatorRule
	{
		public bool IsResponsible(string field)
		{
			return field == "hgt";
		}

		public bool IsValid(string value)
		{
			var match = Regex.Match(value, @"(?<size>\d+)(?<unit>\w+)");
			
			int.TryParse(match.Groups["size"].Value, out var size);
			var unit = match.Groups["unit"].Value;

			return unit switch
			{
				"cm" => size >= 150 && size <= 193,
				"in" => size >= 59 && size <= 76,
				_ => false
			};
		}
	}
}