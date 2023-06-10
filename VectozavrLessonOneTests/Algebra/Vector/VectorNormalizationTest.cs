namespace VectozavrLessonOneTests.Algebra.Vector
{
	public partial class VectorTest
	{
		[TestMethod]
		public void NormalizationTest()
		{
			AlgebraVector.Vector vector = new(new float[] { 5, -2, 7 });
			AlgebraVector.Vector expected = new(
				new float[] 
				{
					5f / (float)Math.Sqrt(78f), 
					-(float)Math.Sqrt(2f / 39f), 
					7f / (float)Math.Sqrt(78f)
				}
			);
			AlgebraVector.Vector result = vector.Normalize();

			for (int row = 0; row < result.Rows; row++)
			{
				Assert.AreEqual(expected[row], result[row], floatDelta, $"Ошибка на строке {row}.");
			}
		}
	}
}
