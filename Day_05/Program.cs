using System;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Day_05.Test")]
namespace Day_05
{
	class Program
	{
		static void Main(string[] args)
		{
			var input = File.ReadAllLines("./input.txt");

			var maxSeatId = input
				.Select(SeatEvaluator.ParseAndEvaluate)
				.Max(seat => seat.CalculateSeatId());
			
			Console.WriteLine($"max seatId: {maxSeatId}");
		}
	}
}