namespace VectozavrLessonOne.Algebra.Vector
{
	public partial class Vector
	{
		/// <summary>
		/// Сложение векторов.
		/// </summary>
		/// <param name="left"></param>
		/// <param name="right"></param>
		/// <returns></returns>
		public static Vector operator +(Vector left, Vector right)
		{
			if (left.Dimensions != right.Dimensions)
			{
				throw new ArgumentException("Векторы должны иметь один размер");
			}

			return FromMatrix(left.ToMatrix() + right.ToMatrix());
		}
	}
}
