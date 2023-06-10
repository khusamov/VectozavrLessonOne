namespace VectozavrLessonOneTests.Algebra.Vector
{
	public partial class VectorTest
	{
		[TestMethod]
		public void ToStringTest()
		{
			AlgebraVector.Vector vector = new(new float[] { 1, 2, 3 });
			StringAssert.Equals(vector.ToString(), "{ 1, 2, 3 }");
		}
	}
}
