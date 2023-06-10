namespace VectozavrLessonOneTests.Algebra.Matrix
{
	public partial class MatrixTest
	{
		[TestMethod]
		public void ToStringTest()
		{
			AlgebraMatrix.Matrix matrix = new(new float[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } });
			StringAssert.Equals(matrix.ToString(), "{ { 1, 2 }, { 3, 4 }, { 5, 6 } }");
		}
	}
}
