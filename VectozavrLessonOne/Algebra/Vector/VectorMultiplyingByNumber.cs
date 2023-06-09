using AlgebraMatrix = VectozavrLessonOne.Algebra.Matrix;

namespace VectozavrLessonOne.Algebra.Vector
{
	public partial class Vector
	{
		/// <summary>
		/// Умножение числа на вектор.
		/// </summary>
		/// <param name="number"></param>
		/// <param name="vector"></param>
		/// <returns></returns>
		public static Vector operator *(float number, Vector vector) => FromMatrix(number * (AlgebraMatrix.Matrix)vector);

		/// <summary>
		/// Умножение вектора на число.
		/// </summary>
		/// <param name="vector"></param>
		/// <param name="number"></param>
		/// <returns></returns>
		public static Vector operator *(Vector vector, float number) => FromMatrix(number * (AlgebraMatrix.Matrix)vector);
	}
}
