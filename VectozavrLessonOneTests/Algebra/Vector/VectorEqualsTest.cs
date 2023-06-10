namespace VectozavrLessonOneTests.Algebra.Vector
{
	public partial class VectorTest
	{
		[TestMethod]
		public void EqualsTest()
		{
			AlgebraVector.Vector left = new(new float[] { 1, 2, 3 });
			AlgebraVector.Vector right = new(new float[] { 1, 2, 3 });

			Assert.IsTrue(left.Equals(right));
			Assert.IsTrue(left == right);
		}

		[TestMethod]
		public void NotEqualsTest()
		{
			AlgebraVector.Vector left = new(new float[] { 1, 2, 3 });
			AlgebraVector.Vector right = new(new float[] { 4, 5, 6 });

			Assert.IsTrue(!left.Equals(right));
			Assert.IsTrue(left != right);
		}
	}
}
