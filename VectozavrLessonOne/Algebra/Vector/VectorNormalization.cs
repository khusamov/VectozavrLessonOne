namespace VectozavrLessonOne.Algebra.Vector
{
	public partial class Vector
	{
		/// <summary>
		/// Нормализация вектора. 
		/// Уменьшение длины вектора до единичной при сохранении направления.
		/// Для нормализации вектора достаточно вычислить его длину и разделить каждый компонент на эту длину.
		/// </summary>
		/// <returns></returns>
		/// <exception cref="ArgumentException"></exception>
		public Vector Normalize()
		{
			if (Length == 0)
			{
				throw new ArgumentException("Нельзя нормализовать нулевой вектор");
			}

			return this / Length;
		}
	}
}
