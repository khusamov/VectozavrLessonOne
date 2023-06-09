namespace VectozavrLessonOneTests
{
	[TestClass]
	public partial class MatrixUnitTest
	{
		private static float floatDelta = 0.000001f;

		[TestMethod]
		public void GetterTest()
		{
			Matrix matrix = new(new float[,] { { 1, 2}, { 3, 4} });
			Assert.AreEqual(1, matrix[0, 0], floatDelta, "Не прочитался элемент [0, 0]");
			Assert.AreEqual(2, matrix[0, 1], floatDelta, "Не прочитался элемент [0, 1]");
			Assert.AreEqual(3, matrix[1, 0], floatDelta, "Не прочитался элемент [1, 0]");
			Assert.AreEqual(4, matrix[1, 1], floatDelta, "Не прочитался элемент [1, 1]");
		}

		[TestMethod]
		public void SetterTest()
		{
			Matrix matrix = new(new float[,] { { 1, 2 }, { 3, 4 } });
			matrix[0, 0] = 10;
			matrix[0, 1] = 20;
			matrix[1, 0] = 30;
			matrix[1, 1] = 40;
			Assert.AreEqual(10, matrix[0, 0], floatDelta, "Не записался элемент [0, 0]");
			Assert.AreEqual(20, matrix[0, 1], floatDelta, "Не записался элемент [0, 1]");
			Assert.AreEqual(30, matrix[1, 0], floatDelta, "Не записался элемент [1, 0]");
			Assert.AreEqual(40, matrix[1, 1], floatDelta, "Не записался элемент [1, 1]");
		}

		[TestMethod]
		public void SizeTest()
		{
			Matrix matrix = new(new float[,] { { 1, 2 }, { 3, 4 }, { 3, 4 } });
			Assert.AreEqual(3, matrix.Rows);
			Assert.AreEqual(2, matrix.Cols);
		}

		[TestMethod]
		public void AdditionTest()
		{
			Matrix left = new(new float[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } });
			Matrix right = new(new float[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } });
			Matrix expected = new(new float[,] { { 2, 4 }, { 6, 8 }, { 10, 12 } });
			Matrix result = left + right;

			for (int i = 0; i < result.Rows; i++) 
			{
				for (int j = 0; j < result.Cols; j++) 
				{
					Assert.AreEqual(expected[i, j], result[i, j], floatDelta, $"Не сложился элемент: [{i}, {j}]");
				}
			}
		}

		[TestMethod]
		public void AdditionArgumentExceptionTest()
		{
			Assert.ThrowsException<ArgumentException>(
				() =>
				{
					Matrix left = new(new float[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } });
					Matrix right = new(new float[,] { { 1, 2 }, { 3, 4 } });
					return left + right;
				},
				"Количество строк складываемых матриц должно совпадать."
			);
			Assert.ThrowsException<ArgumentException>(
				() =>
				{
					Matrix left = new(new float[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } });
					Matrix right = new(new float[,] { { 1, 2, 3 }, { 3, 4, 5 }, { 5, 6, 7 } });
					return left + right;
				},
				"Количество столбцов складываемых матриц должно совпадать."
			);
		}
	}
}