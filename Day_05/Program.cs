using System;
using System.Collections.Generic;
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
			var seats = input.Select(SeatEvaluator.ParseAndEvaluate).ToList();

			Part1(seats);
			Part2(seats);
		}

		private static void Part1(IEnumerable<Seat> seats)
		{
			var maxSeatId = seats.Max(seat => seat.CalculateSeatId());
			Console.WriteLine($"max seatId: {maxSeatId}");
		}

		private static void Part2(IReadOnlyList<Seat> seats)
		{
			var lastSeatId = seats.Min(s => s.CalculateSeatId());
			foreach (var seat in seats.OrderBy(s => s.CalculateSeatId()))
			{
				var currentSeatId = seat.CalculateSeatId();
				if (currentSeatId - lastSeatId > 1)
				{
					Console.WriteLine($"my seatId: {lastSeatId + 1}");
					break;
				}

				lastSeatId = currentSeatId;
			}
		}
	}
}