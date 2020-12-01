using System;
using System.IO;
using System.Linq;

namespace Day_01
{
	class Program
	{
		static void Main(string[] args)
		{
			var input = File
				.ReadLines("./input.txt")
				.Select(line => Convert.ToInt32(line))
				.ToList();
			
			foreach (var number1 in input)
			{
				foreach (var number2 in input)
				{
					foreach (var number3 in input)
					{
						if (number1 == number2 && number2 == number3)
						{
							continue;
						}

						if (number1 + number2 + number3 == 2020)
						{
							Console.WriteLine($"Numbers found: {number1}, {number2}, {number3} result: {number1 * number2 * number3}");
							return;
						}
					}
				}
			}
		}
	}
}