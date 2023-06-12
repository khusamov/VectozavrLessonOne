namespace VectozavrLessonOne.Algebra.Vector
{
	/// <summary>
	/// Размер вектора-столбца.
	/// </summary>
	public class VectorSize
	{
		private readonly int rows = 0;

		/// <summary>
		/// Количество строк вектора.
		/// </summary>
		/// <returns></returns>
		public int Rows
		{
			get => rows;
		}

		/// <summary>
		/// Конструктор размеров вектора-столбца.
		/// </summary>
		/// <param name="rows">Количество строк вектора.</param>
		public VectorSize(int rows)
		{
			this.rows = rows;
		}
	}
}
