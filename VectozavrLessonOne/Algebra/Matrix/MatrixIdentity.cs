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
		public static Matrix Identity(int size)
		{
			Matrix result = new(new float[size, size]);

			for (int i = 0; i < size; i++)
			{
				result[i, i] = 1;
			}

			return result;
		}
	}
}
