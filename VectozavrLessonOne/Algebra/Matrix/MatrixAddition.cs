namespace VectozavrLessonOne.Algebra.Matrix
{
	public partial class Matrix
	{
		/// <summary>
		/// Сложение матриц.
		/// </summary>
		/// <param name="left"></param>
		/// <param name="right"></param>
		/// <returns>Матрица</returns>
		/// <exception cref="ArgumentException"></exception>
		public static Matrix operator +(Matrix left, Matrix right)
		{
			if (left.Cols != right.Cols || left.Rows != right.Rows)
			{
				throw new ArgumentException("Матрицы должны иметь один размер");
			}

			Matrix result = new(new float[left.Rows, left.Cols]);

			for (int i = 0; i < left.Rows; i++)
			{
				for (int j = 0; j < left.Cols; j++)
				{
					result[i, j] = left[i, j] + right[i, j];
				}
			}

			return result;
		}
	}
}
