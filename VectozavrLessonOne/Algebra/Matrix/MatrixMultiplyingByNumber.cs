namespace VectozavrLessonOne.Algebra.Matrix
{
	public partial class Matrix
	{
		/// <summary>
		/// Умножение числа на матрицу.
		/// </summary>
		/// <param name="number">Число</param>
		/// <param name="matrix">Матрица</param>
		/// <returns>Матрица</returns>
		public static Matrix operator *(float number, Matrix matrix)
		{
			Matrix result = new(new float[matrix.Rows, matrix.Cols]);

			for (int i = 0; i < matrix.Rows; i++)
			{
				for (int j = 0; j < matrix.Cols; j++)
				{
					result[i, j] = matrix[i, j] * number;
				}
			}

			return result;
		}

		/// <summary>
		/// Умножение матрицы на число.
		/// </summary>
		/// <param name="matrix">Матрица</param>
		/// <param name="number">Число</param>
		/// <returns>Матрица</returns>
		public static Matrix operator *(Matrix matrix, float number) => number * matrix;
	}
}
