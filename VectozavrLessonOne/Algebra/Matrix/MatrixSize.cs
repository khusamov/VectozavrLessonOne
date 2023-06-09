namespace VectozavrLessonOne.Algebra.Matrix
{
	public partial class Matrix
	{
		/// <summary>
		/// Количество строк матрицы.
		/// </summary>
		/// <returns></returns>
		public int Rows
		{
			get => matrixValues.GetUpperBound(0) + 1;
		}

		/// <summary>
		/// Количество столбцов матрицы.
		/// </summary>
		/// <returns></returns>
		public int Cols
		{
			get => matrixValues.GetUpperBound(1) + 1;
		}
	}
}
