namespace VectozavrLessonOne.Algebra.Matrix
{
	public partial class Matrix
	{
		/// <summary>
		/// Матрица масштабирования.
		/// </summary>
		/// <param name="factor">Вектор-столбец со значениями масштабирования.</param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"></exception>
		public static Matrix Scale(Matrix factor)
		{
			if (factor.Cols != 1)
			{
				throw new ArgumentException("Количество столбцов factor должно быть 1");
			}

			Matrix result = Zero(new MatrixSize(factor.Rows + 1));

			for (int row = 0; row < factor.Rows; row++)
			{
				result[row, row] = factor[row, 0];
			}

			result[factor.Rows, factor.Rows] = 1;

			return result;
		}
	}
}
