namespace VectozavrLessonOne.Algebra.Vector
{
	public partial class Vector
	{
		/// <summary>
		/// Нулевой вектор.
		/// </summary>
		/// <param name="size">Размер вектора</param>
		/// <returns>Матрица</returns>
		public static Vector Zero(int rows) => new(new float[rows]);
	}
}
