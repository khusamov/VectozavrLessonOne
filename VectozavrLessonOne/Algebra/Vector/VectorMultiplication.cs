using AlgebraMatrix = VectozavrLessonOne.Algebra.Matrix;

namespace VectozavrLessonOne.Algebra.Vector
{
	public partial class Vector
	{
		/// <summary>
		/// Векторное произведение.
		/// </summary>
		/// <param name="left"></param>
		/// <param name="right"></param>
		/// <returns></returns>
		public static Vector operator *(Vector left, Vector right) => left.Cross(right);

		/// <summary>
		/// Умножение матрицы на вектор-столбец.
		/// На выходе возвращается именно вектор-столбец, 
		/// потому что эта операция предназначена для трансформации 
		/// вектора при помощи матрицы-трансформации.
		/// </summary>
		/// <param name="left">Матрица</param>
		/// <param name="right">Вектор</param>
		/// <returns>Вектор</returns>
		public static Vector operator *(AlgebraMatrix.Matrix left, Vector right)
		{
			return FromMatrix(left * right.ToMatrix());
		}
	}
}
