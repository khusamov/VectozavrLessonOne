namespace VectozavrLessonOneTests.Algebra.Matrix
{
	public partial class MatrixTest
	{
		[TestMethod]
		public void NegationTest()
		{
			AlgebraMatrix.Matrix matrix = new(new float[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } });
			AlgebraMatrix.Matrix expected = new(new float[,] { { -1, -2 }, { -3, -4 }, { -5, -6 } });
			AlgebraMatrix.Matrix result = -matrix;

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
