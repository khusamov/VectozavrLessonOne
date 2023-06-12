namespace VectozavrLessonOneTests.Algebra.Matrix
{
	public partial class MatrixTest
	{
		[TestMethod]
		public void IdentityTest()
		{
			AlgebraMatrix.Matrix matrix = AlgebraMatrix.Matrix.Identity(new MatrixSize(3));
			Assert.AreEqual(1, matrix[0, 0], floatDelta);
			Assert.AreEqual(0, matrix[0, 1], floatDelta);
			Assert.AreEqual(0, matrix[0, 2], floatDelta);
			Assert.AreEqual(0, matrix[1, 0], floatDelta);
			Assert.AreEqual(1, matrix[1, 1], floatDelta);
			Assert.AreEqual(0, matrix[1, 2], floatDelta);
			Assert.AreEqual(0, matrix[2, 0], floatDelta);
			Assert.AreEqual(0, matrix[2, 1], floatDelta);
			Assert.AreEqual(1, matrix[2, 2], floatDelta);
		}
	}
}
