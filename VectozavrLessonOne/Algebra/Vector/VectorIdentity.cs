namespace VectozavrLessonOne.Algebra.Vector
{
	public partial class Vector
	{
		/// <summary>
		/// Единичный вектор.
		/// Вектор нормированного пространства, длина которого равна единице. 
		/// Единичные вектора используются, в частности, для задания направлений в пространстве.
		/// </summary>
		/// <see cref="https://bit.ly/3qzxyep"/>
		/// <returns></returns>
		public Vector Identity()
		{
			return this / Length;
		}
	}
}
