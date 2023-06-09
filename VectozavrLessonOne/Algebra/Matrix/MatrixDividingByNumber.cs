using System.Diagnostics;

namespace VectozavrLessonOne.Algebra.Matrix
{
	public partial class Matrix
	{
		/// <summary>
		/// Деление матрицы на число.
		/// </summary>
		/// <param name="matrix">Матрица</param>
		/// <param name="number">Число</param>
		/// <returns>Матрица</returns>
		/// <exception cref="ArgumentException"></exception>
		public static Matrix operator /(Matrix matrix, float number)
		{
			if (number == 0)
			{
				throw new ArgumentException("Деление матрицы на ноль");
			}

			return 1 / number * matrix;
		}
	}
}
