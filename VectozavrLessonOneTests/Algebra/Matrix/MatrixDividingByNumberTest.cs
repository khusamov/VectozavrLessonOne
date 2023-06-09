namespace VectozavrLessonOneTests.Algebra.Matrix
{
	public partial class MatrixTest
	{
		[TestMethod]
		public void DividingByNumberTest()
		{
			AlgebraMatrix.Matrix matrix = new(new float[,] { { 10, 20 }, { 30, 40 } });
			AlgebraMatrix.Matrix result = matrix / 10;
			Assert.AreEqual(1, result[0, 0], floatDelta);
			Assert.AreEqual(2, result[0, 1], floatDelta);
			Assert.AreEqual(3, result[1, 0], floatDelta);
			Assert.AreEqual(4, result[1, 1], floatDelta);
		}

		[TestMethod]
		public void DividingByNumberArgumentExceptionTest()
		{
			AlgebraMatrix.Matrix matrix = new(new float[,] { { 10, 20 }, { 30, 40 } });
			Assert.ThrowsException<ArgumentException>(() => matrix / 0);
		}
	}
}
