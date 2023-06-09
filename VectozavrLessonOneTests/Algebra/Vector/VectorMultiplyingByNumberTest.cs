namespace VectozavrLessonOneTests.Algebra.Vector
{
	public partial class VectorTest
	{
		[TestMethod]
		public void MultiplyingVectorByNumberTest()
		{
			AlgebraVector.Vector vector = new(new float[] { 1, 2, 3, 4, 5 });
			AlgebraVector.Vector result = vector * 10;
			Assert.AreEqual(10, result[0], floatDelta, "Не прочитался элемент [0].");
			Assert.AreEqual(20, result[1], floatDelta, "Не прочитался элемент [1].");
			Assert.AreEqual(30, result[2], floatDelta, "Не прочитался элемент [2].");
			Assert.AreEqual(40, result[3], floatDelta, "Не прочитался элемент [3].");
			Assert.AreEqual(50, result[4], floatDelta, "Не прочитался элемент [4].");
		}

		[TestMethod]
		public void MultiplyingNumberByVectorTest()
		{
			AlgebraVector.Vector vector = new(new float[] { 1, 2, 3, 4, 5 });
			AlgebraVector.Vector result = 10 * vector;
			Assert.AreEqual(10, result[0], floatDelta, "Не прочитался элемент [0].");
			Assert.AreEqual(20, result[1], floatDelta, "Не прочитался элемент [1].");
			Assert.AreEqual(30, result[2], floatDelta, "Не прочитался элемент [2].");
			Assert.AreEqual(40, result[3], floatDelta, "Не прочитался элемент [3].");
			Assert.AreEqual(50, result[4], floatDelta, "Не прочитался элемент [4].");
		}
	}
}
