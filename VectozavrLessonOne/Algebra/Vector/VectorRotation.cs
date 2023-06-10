using AlgebraMatrix = VectozavrLessonOne.Algebra.Matrix;

namespace VectozavrLessonOne.Algebra.Vector
{
	public partial class Vector
	{
		/// <summary>
		/// Создать матрицу вращения вокруг данного вектора.
		/// </summary>
		/// <returns>Матрица</returns>
		public AlgebraMatrix.Matrix Rotation()
		{
			return RotationX(X) * RotationY(Y) * RotationZ(Z);
		}
	}
}
