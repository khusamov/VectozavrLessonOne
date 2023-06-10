using AlgebraMatrix = VectozavrLessonOne.Algebra.Matrix;

namespace VectozavrLessonOne.Algebra.Vector
{
	public partial class Vector
	{
		/// <summary>
		/// Создать матрицу из вектора.
		/// </summary>
		/// <returns>Матрица</returns>
		public AlgebraMatrix.Matrix ToMatrix()
		{
			float[] vectorValues = new float[Dimensions];

			for (int row = 0; row < Rows; row++)
			{
				vectorValues[row] = this[row];
			}

			float[,] matrixValues = Vector2MatrixValues(vectorValues);

			return new AlgebraMatrix.Matrix(matrixValues);
		}
	}
}
