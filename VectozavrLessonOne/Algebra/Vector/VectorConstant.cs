namespace VectozavrLessonOne.Algebra.Vector
{
	public partial class Vector
	{
		/// <summary>
		/// Создание вектора с одним значением во всех его компонентах.
		/// </summary>
		/// <param name="rows">Количество строк в новом векторе</param>
		/// <param name="constantValue">Значение ячейки</param>
		/// <returns>Вектор</returns>
		public static Vector Constant(int rows, float constantValue)
		{
			return FromMatrix(Constant(rows, 1, constantValue));
		}
	}
}
