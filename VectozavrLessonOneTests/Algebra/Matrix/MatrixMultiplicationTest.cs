namespace VectozavrLessonOneTests.Algebra.Matrix
{
	public partial class MatrixTest
	{
		[TestMethod]
		public void MultiplicationTest()
		{
			AlgebraMatrix.Matrix left = new(new float[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } });
			AlgebraMatrix.Matrix right = new(new float[,] { { 1, 2, 3 }, { 4, 5, 6 } });
			AlgebraMatrix.Matrix expected = new(new float[,] { { 9, 12, 15 }, { 19, 26, 33 }, { 29, 40, 51 } });
			AlgebraMatrix.Matrix result = left * right;

			for (int row = 0; row < result.Rows; row++)
			{
				for (int col = 0; col < result.Cols; col++)
				{
					Assert.AreEqual(expected[row, col], result[row, col], floatDelta);
				}
			}
		}
	}
}
