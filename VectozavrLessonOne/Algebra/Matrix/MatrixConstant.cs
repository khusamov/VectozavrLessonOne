namespace VectozavrLessonOne.Algebra.Matrix
{
	public partial class Matrix
	{
		/// <summary>
		/// Создание матрицы с одним значением во всех ячейках.
		/// </summary>
		/// <param name="size">Размеры новой матрицы</param>
		/// <param name="constantValue">Значение ячейки</param>
		/// <returns>Матрица</returns>
		public static Matrix Constant(MatrixSize size, float constantValue)
		{
			Matrix result = new(new float[size.Rows, size.Cols]);

			for (int row = 0; row < size.Rows; row++)
			{
				for (int col = 0; col < size.Cols; col++)
				{
					result[row, col] = constantValue;
				}
			}

			return result;
		}
	}
}
