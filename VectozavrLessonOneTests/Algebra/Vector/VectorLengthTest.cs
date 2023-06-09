namespace VectozavrLessonOneTests.Algebra.Vector
{
	public partial class VectorTest
	{
		[TestMethod]
		public void LengthTest()
		{
			AlgebraVector.Vector vector = new(new float[] { 1, 2, 3, 4, 5 });
			float length = (float)Math.Sqrt(1 * 1 + 2 * 2 + 3 * 3 + 4 * 4 + 5 * 5);
			Assert.AreEqual(length, vector.Length, floatDelta);
		}
	}
}
