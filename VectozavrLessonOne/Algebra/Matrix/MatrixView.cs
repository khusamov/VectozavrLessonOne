using AlgebraVector = VectozavrLessonOne.Algebra.Vector;

namespace VectozavrLessonOne.Algebra.Matrix
{
	public partial class Matrix
	{
		/// <summary>
		/// Матрица для камеры.
		/// Перевод координат объекта из мировых в систему координат камеры.
		/// </summary>
		/// <returns></returns>
		public static Matrix View(AlgebraVector.Vector left, AlgebraVector.Vector up, AlgebraVector.Vector lookAt, AlgebraVector.Vector eye)
		{
			return new(
				new float[,]
				{
					{ left.X, left.Y, left.Z, -eye.Dot(left) },
					{ up.X, up.Y, up.Z, -eye.Dot(up) },
					{ lookAt.X, lookAt.Y, lookAt.Z, -eye.Dot(lookAt) },
					{ 0, 0, 0, 1 }
				}
			);
		}
	}
}
