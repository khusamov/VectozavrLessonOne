using AlgebraMatrix = VectozavrLessonOne.Algebra.Matrix;

namespace VectozavrLessonOne.Algebra.Vector
{
	public partial class Vector
	{
		/// <summary>
		/// Создание вектора из матрицы.
		/// </summary>
		/// <param name="matrix">Исходная матрица</param>
		/// <returns>Новый вектор</returns>
		/// <exception cref="ArgumentException"></exception>
		public static Vector FromMatrix(AlgebraMatrix.Matrix matrix)
		{
			if (matrix.Cols != 1)
			{
				throw new ArgumentException("Матрица должна иметь 1 колонку.");
			}

			float[,] matrixValues = new float[matrix.Rows, matrix.Cols];

			for (int i = 0; i < matrix.Rows; i++)
			{
				for (int j = 0; j < matrix.Cols; j++)
				{
					matrixValues[i, j] = matrix[i, j];
				}
			}

			return new Vector(Matrix2VectorValues(matrixValues));
		}
	}
}
