namespace VectozavrLessonOneTests.Algebra.Vector
{
	public partial class VectorTest
	{
		[TestMethod]
		public void DimensionTest()
		{
			AlgebraVector.Vector vector = new(new float[] { 1, 2, 3, 4, 5 });
			Assert.AreEqual(5, vector.Dimensions, "Не правильно вычисляется размерность вектора.");
		}
	}
}
