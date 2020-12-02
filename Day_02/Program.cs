using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Day_02.Part_1;

namespace Day_02
{
	class Program
	{
		static void Main(string[] args)
		{
			var correctPasswords = File
				.ReadAllLines("./input.txt")
				.Select(ParseInputLine)
				.Select(input => IsValidPasswordV2(input.password, input.policy))
				.Count(isValid => isValid);

			Console.WriteLine($"number of correct passwords: {correctPasswords}");
		}
		
		private static (string password, PasswordPolicy policy) ParseInputLine(string input)
		{
			var match = Regex.Match(input, @"(?<min>\d+)-(?<max>\d+) (?<char>\w): (?<password>\w+)");

			var minOccurence = match.Groups["min"].Value;
			var maxOccurence = match.Groups["max"].Value;
			var character = match.Groups["char"].Value;
			var password = match.Groups["password"].Value;

			var policy = new PasswordPolicy
			{
				MinOccurence = Convert.ToInt32(minOccurence),
				MaxOccurence = Convert.ToInt32(maxOccurence),
				Character = Convert.ToChar(character)
			};

			return (password, policy);
		}
		
		private static bool IsValidPasswordV1(string password, PasswordPolicy policy)
		{
			var actualOccurence = password.Count(c => c == policy.Character);
			return actualOccurence >= policy.MinOccurence && actualOccurence <= policy.MaxOccurence;
		}
		
		private static bool IsValidPasswordV2(string password, PasswordPolicy policy)
		{
			var isFirstOccurenceCorrectChar = password[policy.MinOccurence - 1] == policy.Character;
			var isSecondOccurenceCorrectChar = password[policy.MaxOccurence - 1] == policy.Character;

			return isFirstOccurenceCorrectChar ^ isSecondOccurenceCorrectChar;
		}
	}
}