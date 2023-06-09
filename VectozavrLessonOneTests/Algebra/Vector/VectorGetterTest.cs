namespace VectozavrLessonOneTests.Algebra.Vector
{
	public partial class VectorTest
	{
		[TestMethod]
		public void GetterTest()
		{
			AlgebraVector.Vector vector = new(new float[] { 1, 2, 3, 4, 5 });
			Assert.AreEqual(1, vector[0], floatDelta, "Не прочитался элемент [0].");
			Assert.AreEqual(2, vector[1], floatDelta, "Не прочитался элемент [1].");
			Assert.AreEqual(3, vector[2], floatDelta, "Не прочитался элемент [2].");
			Assert.AreEqual(4, vector[3], floatDelta, "Не прочитался элемент [3].");
			Assert.AreEqual(5, vector[4], floatDelta, "Не прочитался элемент [4].");
		}
	}
}
