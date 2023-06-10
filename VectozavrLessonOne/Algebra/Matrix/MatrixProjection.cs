namespace VectozavrLessonOne.Algebra.Matrix
{
	public partial class Matrix
	{
		/// <summary>
		/// Матрица проекции точки на виртуальный нормированный экран (размеры от -1 до 1).
		/// </summary>
		/// <param name="fov">Поле зрения (угол обзора) в радианах</param>
		/// <param name="aspect">Соотношение сторон экрана w/h</param>
		/// <param name="znear"></param>
		/// <param name="zfar"></param>
		/// <returns></returns>
		public static Matrix Projection(float fov, float aspect, float znear, float zfar)
		{
			return new(
				new float[,]
				{
					{ 1 / (MathF.Tan(fov / 2) * aspect), 0, 0, 0 },
					{ 0, 1 / MathF.Tan(fov / 2), 0, 0 },
					{ 0, 0, zfar / (zfar - znear), -zfar * znear / (zfar - znear) },
					{ 0, 0, 1, 0 }
				}
			);
		}
	}
}
