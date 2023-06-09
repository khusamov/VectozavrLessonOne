namespace VectozavrLessonOne.Algebra
{
	public partial class Matrix
	{
		public float this[int row, int column]
		{
			get => matrixValues[row, column];
			set => matrixValues[row, column] = value;
		}
	}
}
