using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day_04
{
	//ugly code, I was tired...
	class Program
	{
		private static readonly PassportValidator _validator = new PassportValidator();

		static void Main(string[] args)
		{
			var input = File.ReadAllLines("./input.txt");
			var passports = FormatPassports(input);
			var validPassports = passports.Count(IsValidPassport);
			
			Console.WriteLine($"valid passports: {validPassports}");
		}

		private static IEnumerable<string> FormatPassports(IEnumerable<string> input)
		{
			var passports = new List<string>();
			var passport = string.Empty;
			foreach (var inputLine in input)
			{
				if (inputLine.Length > 0)
				{
					passport += $" {inputLine}";
					continue;
				}

				passports.Add(passport);
				passport = string.Empty;
			}

			if (!string.IsNullOrEmpty(passport))
			{
				passports.Add(passport);
			}

			return passports;
		}

		private static bool IsValidPassport(string passportDefinition)
		{
			var passport = ParsePassport(passportDefinition);
			return passport.Count == 7 && _validator.IsValid(passport);
		}

		private static Dictionary<string, string> ParsePassport(string passportDefinition)
		{
			var matches = Regex.Matches(passportDefinition, @"(?<field>\w{3}):(?<value>.+?)(?:\s|\z)");
			var passport = new Dictionary<string, string>();
			foreach (Match match in matches)
			{
				var field = match.Groups["field"].Value;
				var value = match.Groups["value"].Value;

				if (field == "cid")
				{
					continue;
				}

				passport.Add(field, value);
			}

			return passport;
		}
	}
}