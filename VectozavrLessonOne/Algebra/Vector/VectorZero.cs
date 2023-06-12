namespace VectozavrLessonOne.Algebra.Vector
{
	public partial class Vector
	{
		/// <summary>
		/// Нулевой вектор.
		/// </summary>
		/// <param name="size">Размер вектора</param>
		/// <returns>Матрица</returns>
		public static Vector Zero(VectorSize size) => new(new float[size.Rows]);
	}
}
