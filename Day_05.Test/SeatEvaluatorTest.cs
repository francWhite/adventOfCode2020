using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Day_05.Test
{
	[TestClass]
	public class SeatEvaluatorTest
	{
		[TestMethod]
		[DataRow("BFFFBBFRRR", 70, 7, 567)]
		[DataRow("FFFBBBFRRR", 14, 7, 119)]
		[DataRow("BBFFBBFRLL", 102, 4, 820)]
		[DataRow("FBFBBFFRLR", 44, 5, 357)]
		public void ParseAndEvaluate(string seatDefinition, int expectedRow, int expectedColumn, int expectedSeatId)
		{
			var seat = SeatEvaluator.ParseAndEvaluate(seatDefinition);

			using (new AssertionScope())
			{
				seat.Row.Should().Be(expectedRow);
				seat.Column.Should().Be(expectedColumn);
				seat.CalculateSeatId().Should().Be(expectedSeatId);
			}
		}
	}
}