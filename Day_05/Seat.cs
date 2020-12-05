namespace Day_05
{
	internal class Seat
	{
		public Seat(int row, int column)
		{
			Row = row;
			Column = column;
		}

		public int Row { get; set; }
		public int Column { get; set; }

		public int CalculateSeatId()
		{
			return Row * 8 + Column;
		}
	}
}