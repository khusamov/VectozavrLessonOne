namespace VectozavrLessonOneTests.Algebra.Matrix
{
	public partial class MatrixTest
	{
		[TestMethod]
		public void AdditionTest()
		{
			AlgebraMatrix.Matrix left = new(new float[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } });
			AlgebraMatrix.Matrix right = new(new float[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } });
			AlgebraMatrix.Matrix expected = new(new float[,] { { 2, 4 }, { 6, 8 }, { 10, 12 } });
			AlgebraMatrix.Matrix result = left + right;

			for (int row = 0; row < result.Rows; row++)
			{
				for (int col = 0; col < result.Cols; col++)
				{
					Assert.AreEqual(expected[row, col], result[row, col], floatDelta, $"Не сложился элемент: [{row}, {col}].");
				}
			}
		}

		[TestMethod]
		public void AdditionRowArgumentExceptionTest()
		{
			AlgebraMatrix.Matrix left = new(new float[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } });
			AlgebraMatrix.Matrix right = new(new float[,] { { 1, 2 }, { 3, 4 } });
			Assert.ThrowsException<ArgumentException>(
				 () => left + right,
				 "Количество строк складываемых матриц должно совпадать."
			);
		}

		[TestMethod]
		public void AdditionColArgumentExceptionTest()
		{
			AlgebraMatrix.Matrix left = new(new float[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } });
			AlgebraMatrix.Matrix right = new(new float[,] { { 1, 2, 3 }, { 3, 4, 5 }, { 5, 6, 7 } });
			Assert.ThrowsException<ArgumentException>(
				 () => left + right,
				 "Количество столбцов складываемых матриц должно совпадать."
			);
		}
	}
}
