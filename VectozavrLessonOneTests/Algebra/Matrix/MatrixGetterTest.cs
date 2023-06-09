namespace VectozavrLessonOneTests.Algebra.Matrix
{
	public partial class MatrixTest
	{
		[TestMethod]
		public void GetterTest()
		{
			AlgebraMatrix.Matrix matrix = new(new float[,] { { 1, 2 }, { 3, 4 } });
			Assert.AreEqual(1, matrix[0, 0], floatDelta, "Не прочитался элемент [0, 0].");
			Assert.AreEqual(2, matrix[0, 1], floatDelta, "Не прочитался элемент [0, 1].");
			Assert.AreEqual(3, matrix[1, 0], floatDelta, "Не прочитался элемент [1, 0].");
			Assert.AreEqual(4, matrix[1, 1], floatDelta, "Не прочитался элемент [1, 1].");
		}
	}
}
