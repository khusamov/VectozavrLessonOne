namespace VectozavrLessonOne.Algebra.Matrix
{
	/// <summary>
	/// Матрица. Реализация разных операций над матрицами.
	/// </summary>
	/// <see cref="https://bit.ly/3NkFrx3"/>
	public partial class Matrix
	{
		private float[,] matrixValues;

		public Matrix(float[,] matrixValues)
		{
			this.matrixValues = matrixValues;
		}
	}
}
