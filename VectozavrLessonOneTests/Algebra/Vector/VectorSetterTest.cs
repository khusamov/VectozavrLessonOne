namespace VectozavrLessonOneTests.Algebra.Vector
{
	public partial class VectorTest
	{
		[TestMethod]
		public void SetterTest()
		{
			AlgebraVector.Vector vector = new(new float[] { 1, 2, 3, 4, 5 });
			vector[0] = 10;
			vector[1] = 20;
			vector[2] = 30;
			vector[3] = 40;
			vector[4] = 50;
			Assert.AreEqual(10, vector[0], floatDelta, "Не записался элемент [0].");
			Assert.AreEqual(20, vector[1], floatDelta, "Не записался элемент [1].");
			Assert.AreEqual(30, vector[2], floatDelta, "Не записался элемент [2].");
			Assert.AreEqual(40, vector[3], floatDelta, "Не записался элемент [3].");
			Assert.AreEqual(50, vector[4], floatDelta, "Не записался элемент [4].");
		}
	}
}
