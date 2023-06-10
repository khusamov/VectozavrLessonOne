namespace VectozavrLessonOne.Algebra.Matrix
{
	public partial class Matrix
	{
		/// <summary>
		/// Нулевая матрица.
		/// </summary>
		/// <param name="rows">Количество строк матрицы</param>
		/// <param name="cols">Количество столбцов матрицы. Можно не указывать, тогда будет квадратная матрица</param>
		/// <returns>Матрица</returns>
		public static Matrix Zero(int rows, int? cols = null)
		{
			int _cols = (
				cols is null 
					? rows 
					: (int)cols
			);

			return new(new float[rows, _cols]);
		}
	}
}
