namespace VectozavrLessonOne.Algebra.Matrix
{
	public partial class Matrix
	{
		/// <summary>
		/// Получить или сохранить значение ячейки из матрицы.
		/// </summary>
		/// <param name="row">Строка</param>
		/// <param name="column">Столбец</param>
		/// <returns></returns>
		public float this[int row, int column]
		{
			get => matrixValues[row, column];
			set => matrixValues[row, column] = value;
		}
	}
}
