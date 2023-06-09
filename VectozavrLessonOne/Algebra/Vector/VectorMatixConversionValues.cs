namespace VectozavrLessonOne.Algebra.Vector
{
	public partial class Vector
	{
		/// <summary>
		/// Конвертация внутренного массива значений вектора во внутренний массив значений матрицы.
		/// </summary>
		/// <param name="vectorValues">Одномерный массив значений вектора</param>
		/// <returns>Двухмерный массив значений матрицы</returns>
		private static float[,] Vector2MatrixValues(float[] vectorValues)
		{
			float[,] matrixValues = new float[vectorValues.Length, 1];
			for (int i = 0; i < vectorValues.Length; i++)
			{
				matrixValues[i, 0] = vectorValues[i];
			}
			return matrixValues;
		}

		/// <summary>
		/// Конвертация внутренного массива значений матрицы во внутренний массив значений вектора.
		/// </summary>
		/// <param name="matrixValues">Двухмерный массив значений матрицы</param>
		/// <returns>Одномерный массив значений вектора</returns>
		private static float[] Matrix2VectorValues(float[,] matrixValues)
		{
			int rows = matrixValues.GetUpperBound(0) + 1;

			float[] vectorValues = new float[rows];
			for (int i = 0; i < rows; i++)
			{
				vectorValues[i] = matrixValues[i, 0];
			}
			return vectorValues;
		}
	}
}
