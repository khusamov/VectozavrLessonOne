namespace VectozavrLessonOne.Algebra.Vector
{
	public partial class Vector
	{
		/// <summary>
		/// Унарная операция отрицания.
		/// </summary>
		/// <param name="vector"></param>
		/// <returns></returns>
		public static Vector operator -(Vector vector)
		{
			return -1 * vector;
		}
	}
}
