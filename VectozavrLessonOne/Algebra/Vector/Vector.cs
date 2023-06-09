using AlgebraMatrix = VectozavrLessonOne.Algebra.Matrix;

namespace VectozavrLessonOne.Algebra.Vector
{
	/// <summary>
	/// Вектор-столбец. Операции над векторами.
	/// </summary>
	public partial class Vector : AlgebraMatrix.Matrix
	{
		/// <summary>
		/// Конструктор вектора.
		/// </summary>
		/// <param name="vectorValues"></param>
		/// <exception cref="ArgumentException"></exception>
		public Vector(float[] vectorValues) : base(Vector2MatrixValues(vectorValues))
		{
			if (Cols != 1)
			{
				throw new ArgumentException("Вектор должен содержать только 1 колонку.");
			}
		}
	}
}
