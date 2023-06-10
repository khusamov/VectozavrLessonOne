namespace VectozavrLessonOne.Algebra.Matrix
{
	public partial class Matrix
	{
		/// <summary>
		/// Унарная операция отрицания.
		/// </summary>
		/// <param name="matrix"></param>
		/// <returns></returns>
		public static Matrix operator -(Matrix matrix)
		{
			return -1 * matrix;
		}
	}
}
