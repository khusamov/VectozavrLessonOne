namespace VectozavrLessonOne.Algebra.Matrix
{
	public partial class Matrix
	{
		/// <summary>
		/// Умножение матриц.
		/// </summary>
		/// <param name="left"></param>
		/// <param name="right"></param>
		/// <see>https://bit.ly/43om7ot</see>
		/// <returns></returns>
		/// <exception cref="ArgumentException"></exception>
		public static Matrix operator *(Matrix left, Matrix right)
		{
			if (left.Cols != right.Rows)
			{
				// Матрицы left и right могут быть перемножены, если они совместимы в том смысле,
				// что число столбцов матрицы left равно числу строк right.
				// https://bit.ly/43om7ot
				throw new ArgumentException("Матрицы должны быть совместимы");
			}

			int l = left.Rows;
			int m = left.Cols;
			int n = right.Cols;
			Matrix result = new Matrix(new float[l, n]);

			for (int i = 0; i < l; i++)
			{
				for (int j = 0; j < n; j++)
				{
					for (int r = 0; r < m; r++)
					{
						result[i, j] += left[i, r] * right[r, j];
					}
				}
			}

			return result;
		}
	}
}
