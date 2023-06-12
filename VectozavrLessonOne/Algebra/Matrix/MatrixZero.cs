namespace VectozavrLessonOne.Algebra.Matrix
{
	public partial class Matrix
	{
		/// <summary>
		/// Нулевая матрица.
		/// </summary>
		/// <param name="size">Размер матрицы</param>
		/// <returns>Матрица</returns>
		public static Matrix Zero(MatrixSize size) => new(new float[size.Rows, size.Cols]);
	}
}
