namespace VectozavrLessonOne.Algebra.Matrix
{
	public partial class Matrix
	{
		/// <summary>
		/// Матрица поворота относительно оси Y.
		/// </summary>
		/// <see cref="https://bit.ly/2VKEGFc"/>
		public static Matrix RotationY(float angle)
		{
			float cos = MathF.Cos(angle);
			float sin = MathF.Sin(angle);
			return new Matrix(
				new float[,]
				{
					{ cos, 0, sin, 0 },
					{ 0, 1, 0, 0 },
					{ -sin, 0, cos, 0 },
					{ 0, 0, 0, 1 }
				}
			);
		}
	}
}
