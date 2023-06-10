namespace VectozavrLessonOne.Algebra.Matrix
{
	public partial class Matrix
	{
		/// <summary>
		/// Матрица перемещения.
		/// </summary>
		/// <param name="direction">Вектор-столбец направления и дистанции</param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"></exception>
		public static Matrix Translation(Matrix direction)
		{
			if (direction.Cols != 1)
			{
				throw new ArgumentException("Количество столбцов direction должно быть 1");
			}

			Matrix result = Zero(direction.Rows + 1);

			for (int row = 0; row < direction.Rows + 1; row++)
			{
				result[row, row] = 1;
			}

			for (int row = 0; row < direction.Rows; row++)
			{
				result[result.Rows - 1, row] = direction[0, row];
			}

			return result;
		}
	}
}
