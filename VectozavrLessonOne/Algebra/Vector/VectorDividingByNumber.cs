using AlgebraMatrix = VectozavrLessonOne.Algebra.Matrix;

namespace VectozavrLessonOne.Algebra.Vector
{
	public partial class Vector
	{
		/// <summary>
		/// Деление вектора на число.
		/// </summary>
		/// <param name="vector"></param>
		/// <param name="number"></param>
		/// <returns></returns>
		public static Vector operator /(Vector vector, float number) => FromMatrix((AlgebraMatrix.Matrix)vector / number);
	}
}
