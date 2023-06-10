namespace VectozavrLessonOneTests.Algebra.Vector
{
	public partial class VectorTest
	{
		[TestMethod]
		public void DotTest()
		{
			AlgebraVector.Vector left = new(new float[] { 1, 2, 3 });
			AlgebraVector.Vector right = new(new float[] { 4, 5, 6 });
			float expected = 32.0f;
			float result = left.Dot(right);

			Assert.AreEqual(expected, result, floatDelta);
		}
	}
}
