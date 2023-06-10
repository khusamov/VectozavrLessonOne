namespace VectozavrLessonOne.Algebra.Matrix
{
	public partial class Matrix
	{
		/// <summary>
		/// Создание матрицы с одним значением во всех ячейках.
		/// </summary>
		/// <param name="rows">Количество строк в новой матрице</param>
		/// <param name="cols">Количество столбцов в новой матрице</param>
		/// <param name="constantValue">Значение ячейки</param>
		/// <returns>Матрица</returns>
		public static Matrix Constant(int rows, int cols, float constantValue)
		{
			Matrix result = new(new float[rows, cols]);

			for (int row = 0; row < rows; row++)
			{
				for (int col = 0; col < cols; col++)
				{
					result[row, col] = constantValue;
				}
			}

			return result;
		}

		/// <summary>
		/// Создание квадратной матрицы с одним значением во всех ячейках.
		/// </summary>
		/// <param name="size">Количество строк и столбцов в новой матрице</param>
		/// <param name="constantValue">Значение ячейки</param>
		/// <returns></returns>
		public static Matrix Constant(int size, float constantValue) => Constant(size, size, constantValue);
	}
}
