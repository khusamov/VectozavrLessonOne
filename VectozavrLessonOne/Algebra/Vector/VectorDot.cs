namespace VectozavrLessonOne.Algebra.Vector
{
	public partial class Vector
	{
		/// <summary>
		/// Скалярное произведение векторов.
		/// Это по сути определение длины проекции вектора this на vector.
		/// </summary>
		/// <param name="vector"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"></exception>
		public float Dot(Vector vector)
		{
			if (Dimensions != vector.Dimensions)
			{
				throw new ArgumentException("Размерность векторов должна быть одинаковой");
			}

			float result = 0.0f;

			for (int i = 0; i < Dimensions; i++)
			{
				result += this[i] * vector[i];
			}

			return result;
		}
	}
}
