namespace VectozavrLessonOne.Algebra.Matrix
{
	public partial class Matrix
	{
		/// <summary>
		/// Единичная матрица.
		/// Матрица, при умножении на которую любая матрица (или вектор) остается неизменной, 
		/// является диагональной матрицей с единичными (всеми) диагональными элементами.
		/// </summary>
		/// <see cref="https://bit.ly/3qAWjXC"/>
		/// <param name="size">Размер матрицы.</param>
		/// <returns></returns>
		public static Matrix Identity(MatrixSize size)
		{
			if (size.Rows != size.Cols)
			{
				throw new ArgumentException("Матрица должна быть квадратной");
			}

			Matrix result = new(new float[size.Rows, size.Cols]);

			for (int row = 0; row < size.Rows; row++)
			{
				result[row, row] = 1;
			}

			return result;
		}
	}
}
