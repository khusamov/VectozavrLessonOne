namespace VectozavrLessonOneTests.Algebra.Matrix
{
	public partial class MatrixTest
	{
		[TestMethod]
		public void SizeTest()
		{
			AlgebraMatrix.Matrix matrix = new(new float[,] { { 1, 2 }, { 3, 4 }, { 3, 4 } });
			Assert.AreEqual(3, matrix.Rows, "Не правильно вычисляется количество строк.");
			Assert.AreEqual(2, matrix.Cols, "Не правильно вычисляется количество столбцов.");
		}
	}
}
