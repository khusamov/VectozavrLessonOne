using AlgebraMatrix = VectozavrLessonOne.Algebra.Matrix;

namespace VectozavrLessonOne.Algebra.Vector
{
	public partial class Vector
	{
		/// <summary>
		/// Создать матрицу вращения по трем осям.
		/// </summary>
		/// <returns>Матрица</returns>
		public AlgebraMatrix.Matrix RotationMatrix()
		{
			return RotationX(X) * RotationY(Y) * RotationZ(Z);
		}

		/// <summary>
		/// Создать матрицу вращения вокруг данного вектора на определенный угол.
		/// </summary>
		/// <param name="angle">Угол, на который следует выполнить вращение</param>
		/// <returns>Матрица</returns>
		public AlgebraMatrix.Matrix RotationMatrix(float angle)
		{
			Vector normal = Normalize();
			float cos = MathF.Cos(angle), sin = MathF.Sin(angle);
			return new(
				new float[,]
				{
					{ 
						cos + (1.0f - cos) * normal.X * normal.X, 
						(1.0f - cos) * normal.X * normal.Y - sin * normal.Z,
						(1.0f - cos) * normal.X * normal.Z - sin * normal.Y,
						0
					},
					{
						(1.0f - cos) * normal.X * normal.Y - sin * normal.Z,
						cos + (1.0f - cos) * normal.Y * normal.Y,
						(1.0f - cos) * normal.Y * normal.Z - sin * normal.X,
						0
					},
					{
						(1.0f - cos) * normal.Z * normal.X - sin * normal.Y,
						(1.0f - cos) * normal.Y * normal.Z - sin * normal.X,
						cos + (1.0f - cos) * normal.Z * normal.Z,
						0
					},
					{
						0, 0, 0, 1
					}
				}
			);
		}
	}
}
