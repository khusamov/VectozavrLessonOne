namespace VectozavrLessonOneTests.Algebra.Vector
{
	public partial class VectorTest
	{
		[TestMethod]
		public void IdentityTest()
		{
			AlgebraVector.Vector vector = new AlgebraVector.Vector(new float[] { 1, 2, 3, 4, 5 }).Identity();
			float length = (float)Math.Sqrt(1 * 1 + 2 * 2 + 3 * 3 + 4 * 4 + 5 * 5);
			Assert.AreEqual(1 / length, vector[0], floatDelta);
			Assert.AreEqual(2 / length, vector[1], floatDelta);
			Assert.AreEqual(3 / length, vector[2], floatDelta);
			Assert.AreEqual(4 / length, vector[3], floatDelta);
			Assert.AreEqual(5 / length, vector[4], floatDelta);
		}
	}
}
