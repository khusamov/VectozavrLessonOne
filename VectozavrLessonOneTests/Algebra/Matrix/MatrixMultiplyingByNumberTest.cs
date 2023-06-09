namespace VectozavrLessonOneTests.Algebra.Matrix
{
	public partial class MatrixTest
	{
		[TestMethod]
		public void MultiplyingMatrixByNumberTest()
		{
			AlgebraMatrix.Matrix matrix = new(new float[,] { { 10, 20 }, { 30, 40 } });
			AlgebraMatrix.Matrix result = matrix * 10;
			Assert.AreEqual(100, result[0, 0], floatDelta);
			Assert.AreEqual(200, result[0, 1], floatDelta);
			Assert.AreEqual(300, result[1, 0], floatDelta);
			Assert.AreEqual(400, result[1, 1], floatDelta);
		}

		[TestMethod]
		public void MultiplyingNumberByMatrixTest()
		{
			AlgebraMatrix.Matrix matrix = new(new float[,] { { 10, 20 }, { 30, 40 } });
			AlgebraMatrix.Matrix result = 10 * matrix;
			Assert.AreEqual(100, result[0, 0], floatDelta);
			Assert.AreEqual(200, result[0, 1], floatDelta);
			Assert.AreEqual(300, result[1, 0], floatDelta);
			Assert.AreEqual(400, result[1, 1], floatDelta);
		}
	}
}
