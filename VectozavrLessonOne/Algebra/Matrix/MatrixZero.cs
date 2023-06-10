namespace VectozavrLessonOne.Algebra.Matrix
{
	public partial class Matrix
	{
		/// <summary>
		/// Нулевая матрица.
		/// </summary>
		/// <param name="rows">Размер матрицы</param>
		/// <param name="cols">Размер матрицы</param>
		/// <returns>Матрица</returns>
		public static Matrix Zero(int rows, int? cols = null) => new(new float[rows, cols is null ? rows : (int)cols]);
	}
}
