namespace VectozavrLessonOne.Algebra.Matrix
{
	public partial class Matrix
	{
		/// <summary>
		/// Матрица для проекции точки с нормированного экрана на реальный экран монитора.
		/// </summary>
		/// <param name="width">Ширина экрана в пикселах</param>
		/// <param name="height">Высота экрана в пикселах</param>
		/// <returns></returns>
		public static Matrix Screen(int width, int height)
		{
			return new(
				new float[,]
				{
					{ -0.5f * width, 0, 0, 0.5f * width },
					{ 0, -0.5f * height, 0, 0.5f * height },
					{ 0, 0, 1, 0 },
					{ 0, 0, 0, 1 }
				}
			);
		}
	}
}
