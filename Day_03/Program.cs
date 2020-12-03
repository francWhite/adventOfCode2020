using System;
using System.Collections.Generic;
using System.IO;

namespace Day_03
{
	class Program
	{
		static void Main(string[] args)
		{
			var input = File.ReadAllLines("./input.txt");
			var map = BuildMap(input);

			long productOfCollisions = CountTreeCollisions(map, 1, 1);
			productOfCollisions *= CountTreeCollisions(map, 3, 1);
			productOfCollisions *= CountTreeCollisions(map, 5, 1);
			productOfCollisions *= CountTreeCollisions(map, 7, 1);
			productOfCollisions *= CountTreeCollisions(map, 1, 2);
			
			Console.WriteLine($"product of all collisions: {productOfCollisions}");
		}

		private static int[,] BuildMap(IReadOnlyList<string> input)
		{
			var height = input.Count;
			var width = input[0].Length;
			var map = new int[width, height];

			for (var y = 0; y < input.Count; y++)
			{
				for (var x = 0; x < input[y].Length; x++)
				{
					map[x, y] = input[y][x] == '#' ? 1 : 0;
				}
			}

			return map;
		}

		private static int CountTreeCollisions(int[,] map, int offsetX, int offsetY)
		{
			var width = map.GetLength(0);
			var height = map.GetLength(1);

			var x = 0;
			var y = 0;
			var collisions = 0;
			
			while (y < height)
			{
				x += offsetX;
				y += offsetY;

				if (x >= width)
				{
					x -= width;
				}

				if (y >= height)
				{
					break;
				}

				collisions += map[x, y];
			}

			return collisions;
		}
	}
}