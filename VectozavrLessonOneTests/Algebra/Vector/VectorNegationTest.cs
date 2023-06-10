namespace VectozavrLessonOneTests.Algebra.Vector
{
	public partial class VectorTest
	{
		[TestMethod]
		public void NegationTest()
		{
			AlgebraVector.Vector vector = new(new float[] { 1, 2, 3 });
			AlgebraVector.Vector expected = new(new float[] { -1, -2, -3 });
			AlgebraVector.Vector result = -vector;

			for (int row = 0; row < result.Rows; row++)
			{
				Assert.AreEqual(expected[row], result[row], floatDelta, $"Ошибка на строке {row}.");
			}
		}
	}
}
