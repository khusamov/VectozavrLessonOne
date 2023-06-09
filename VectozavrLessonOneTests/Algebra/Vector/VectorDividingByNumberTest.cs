namespace VectozavrLessonOneTests.Algebra.Vector
{
	public partial class VectorTest
	{
		[TestMethod]
		public void DividingByNumberTest()
		{
			AlgebraVector.Vector vector = new(new float[] { 10, 20, 30, 40, 50 });
			AlgebraVector.Vector result = vector / 10;
			Assert.AreEqual(1, result[0], floatDelta, "Не прочитался элемент [0].");
			Assert.AreEqual(2, result[1], floatDelta, "Не прочитался элемент [1].");
			Assert.AreEqual(3, result[2], floatDelta, "Не прочитался элемент [2].");
			Assert.AreEqual(4, result[3], floatDelta, "Не прочитался элемент [3].");
			Assert.AreEqual(5, result[4], floatDelta, "Не прочитался элемент [4].");
		}
	}
}
