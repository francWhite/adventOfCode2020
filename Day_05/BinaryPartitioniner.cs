using System.Collections.Generic;
using System.Linq;

namespace Day_05
{
	internal static class BinaryPartitioner
	{
		public static int Partition(Queue<PartitionStep> partitionSteps, int min, int max)
		{
			var currentStep = partitionSteps.Dequeue();
			var difference = max - min;
			var differenceHalf = difference / 2;
			
			if (currentStep == PartitionStep.Lower)
			{
				max = min + differenceHalf;
			}
			else
			{
				min = max - differenceHalf;
			}

			return partitionSteps.Any() 
				? Partition(partitionSteps, min, max) 
				: min;
		}
	}
}