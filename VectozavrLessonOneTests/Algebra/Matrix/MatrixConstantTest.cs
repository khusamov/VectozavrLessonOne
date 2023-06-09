namespace VectozavrLessonOneTests.Algebra.Matrix
{
	public partial class MatrixTest
	{
		[TestMethod]
		public void ConstantTest()
		{
			AlgebraMatrix.Matrix matrix = AlgebraMatrix.Matrix.Constant(3, 3, 100);
			Assert.AreEqual(100, matrix[0, 0], floatDelta);
			Assert.AreEqual(100, matrix[0, 1], floatDelta);
			Assert.AreEqual(100, matrix[0, 2], floatDelta);
			Assert.AreEqual(100, matrix[1, 0], floatDelta);
			Assert.AreEqual(100, matrix[1, 1], floatDelta);
			Assert.AreEqual(100, matrix[1, 2], floatDelta);
			Assert.AreEqual(100, matrix[2, 0], floatDelta);
			Assert.AreEqual(100, matrix[2, 1], floatDelta);
			Assert.AreEqual(100, matrix[2, 2], floatDelta);
		}
	}
}
