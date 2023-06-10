namespace VectozavrLessonOne.Algebra.Matrix
{
	public partial class Matrix
	{
		/// <summary>
		/// Количество строк матрицы.
		/// </summary>
		/// <returns></returns>
		public int Rows
		{
			get => matrixValues.GetUpperBound(0) + 1;
		}

		/// <summary>
		/// Количество столбцов матрицы.
		/// </summary>
		/// <returns></returns>
		public int Cols
		{
			get => matrixValues.GetUpperBound(1) + 1;
		}

		/// <summary>
		/// Размер матрицы.
		/// </summary>
		public MatrixSize Size
		{
			get => new(Rows, Cols);
		}
	}

	/// <summary>
	/// Размеры матрицы.
	/// </summary>
	public class MatrixSize
	{
		private readonly int rows = 0;
		private readonly int cols = 0;

		/// <summary>
		/// Количество строк матрицы.
		/// </summary>
		/// <returns></returns>
		public int Rows
		{
			get => rows;
		}

		/// <summary>
		/// Количество столбцов матрицы.
		/// </summary>
		/// <returns></returns>
		public int Cols
		{
			get => cols;
		}

		/// <summary>
		/// Конструктор размеров матрицы.
		/// </summary>
		/// <param name="rows">Количество строк будущей матрицы</param>
		/// <param name="cols">Количество столбцов будущей матрицы. Если не указать, то будет создаваться квадратная матрица</param>
		public MatrixSize(int rows, int? cols = null)
		{
			this.rows = rows;
			this.cols = cols is null ? rows : (int)cols ;
		}
	}
}
