namespace VectozavrLessonOneTests.Algebra.Matrix
{
	public partial class MatrixTest
	{
		[TestMethod]
		public void SetterTest()
		{
			AlgebraMatrix.Matrix matrix = new(new float[,] { { 1, 2 }, { 3, 4 } });
			matrix[0, 0] = 10;
			matrix[0, 1] = 20;
			matrix[1, 0] = 30;
			matrix[1, 1] = 40;
			Assert.AreEqual(10, matrix[0, 0], floatDelta, "Не записался элемент [0, 0].");
			Assert.AreEqual(20, matrix[0, 1], floatDelta, "Не записался элемент [0, 1].");
			Assert.AreEqual(30, matrix[1, 0], floatDelta, "Не записался элемент [1, 0].");
			Assert.AreEqual(40, matrix[1, 1], floatDelta, "Не записался элемент [1, 1].");
		}
	}
}
