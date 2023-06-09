namespace VectozavrLessonOneTests.Algebra.Vector
{
	public partial class VectorTest
	{
		[TestMethod]
		public void ConstantTest()
		{
			AlgebraVector.Vector vector = AlgebraVector.Vector.Constant(3, 100);
			Assert.AreEqual(100, vector[0], floatDelta, "Не прочитался элемент [0].");
			Assert.AreEqual(100, vector[1], floatDelta, "Не прочитался элемент [1].");
			Assert.AreEqual(100, vector[2], floatDelta, "Не прочитался элемент [2].");
		}
	}
}
