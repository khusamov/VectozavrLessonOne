namespace VectozavrLessonOne.Algebra.Vector
{
	public partial class Vector
	{
		/// <summary>
		/// Маленькое число. Используется в операциях сравнения векторов.
		/// </summary>
		private static float Epsilon
		{
			get => 0.000001f;
		}
	}
}
