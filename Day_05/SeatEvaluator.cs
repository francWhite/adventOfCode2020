using System.Collections.Generic;
using System.Linq;

namespace Day_05
{
	internal static class SeatEvaluator
	{
		private const int MaxRow = 127;
		private const int MaxCol = 7;

		public static Seat ParseAndEvaluate(string input)
		{
			var row = EvaluateRow(input);
			var column = EvaluateColumn(input);

			return new Seat(row, column);
		}

		private static int EvaluateRow(string input)
		{
			var rowDefinition = input.Substring(0, 7);

			var steps = rowDefinition
				.Select(c => c == 'F' ? PartitionStep.Lower : PartitionStep.Upper);

			return BinaryPartitioner.Partition(new Queue<PartitionStep>(steps), 0, MaxRow);
		}

		private static int EvaluateColumn(string input)
		{
			var rowDefinition = input.Substring(7);
			
			var steps = rowDefinition
				.Select(c => c == 'L' ? PartitionStep.Lower : PartitionStep.Upper);
			
			return BinaryPartitioner.Partition(new Queue<PartitionStep>(steps), 0, MaxCol);
		}
	}
}