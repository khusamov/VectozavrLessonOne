namespace VectozavrLessonOne.Algebra.Matrix
{
	public partial class Matrix
	{
		/// <summary>
		/// Матрица поворота относительно оси X.
		/// </summary>
		/// <see cref="https://bit.ly/2VKEGFc"/>
		public static Matrix RotationX(float angle)
		{
			float cos = MathF.Cos(angle);
			float sin = MathF.Sin(angle);
			return new Matrix(
				new float[,]
				{
					{ 1, 0, 0, 0 },
					{ 0, cos, -sin, 0 },
					{ 0, sin, cos, 0 },
					{ 0, 0, 0, 1 }
				}
			);
		}
	}
}
