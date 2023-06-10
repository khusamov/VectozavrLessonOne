namespace VectozavrLessonOneTests.Algebra.Matrix
{
	public partial class MatrixTest
	{
		[TestMethod]
		public void SubtractionTest()
		{
			AlgebraMatrix.Matrix left = new(new float[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } });
			AlgebraMatrix.Matrix right = new(new float[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } });
			AlgebraMatrix.Matrix expected = new(new float[,] { { 0, 0 }, { 0, 0 }, { 0, 0 } });
			AlgebraMatrix.Matrix result = left - right;

			for (int row = 0; row < result.Rows; row++)
			{
				for (int col = 0; col < result.Cols; col++)
				{
					Assert.AreEqual(expected[row, col], result[row, col], floatDelta, $"Не сложился элемент: [{row}, {col}].");
				}
			}
		}
	}
}
