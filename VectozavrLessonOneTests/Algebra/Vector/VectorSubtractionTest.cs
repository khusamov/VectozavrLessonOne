namespace VectozavrLessonOneTests.Algebra.Vector
{
	public partial class VectorTest
	{
		[TestMethod]
		public void SubtractionTest()
		{
			AlgebraVector.Vector left = new(new float[] { 1, 2, 3 });
			AlgebraVector.Vector right = new(new float[] { 4, 5, 6 });
			AlgebraVector.Vector expected = new(new float[] { -3, -3, -3 });
			AlgebraVector.Vector result = left - right;

			for (int row = 0; row < result.Rows; row++)
			{
				Assert.AreEqual(expected[row], result[row], floatDelta, $"Ошибка на строке {row}.");
			}
		}
	}
}
