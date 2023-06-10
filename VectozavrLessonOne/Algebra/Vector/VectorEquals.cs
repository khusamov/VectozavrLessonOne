namespace VectozavrLessonOne.Algebra.Vector
{
	public partial class Vector
	{
		/// <summary>
		/// Сравнение векторов.
		/// </summary>
		/// <param name="left"></param>
		/// <param name="right"></param>
		/// <returns></returns>
		public static bool operator ==(Vector left, Vector right) => left.Equals(right);

		/// <summary>
		/// Сравнение векторов.
		/// </summary>
		/// <param name="left"></param>
		/// <param name="right"></param>
		/// <returns></returns>
		public static bool operator !=(Vector left, Vector right) => !left.Equals(right);

		/// <summary>
		/// Сравнение векторов.
		/// </summary>
		/// <param name="obj">Тестовый вектор</param>
		/// <returns>Возвращает true, если компоненты векторов равны</returns>
		/// <exception cref="ArgumentException"></exception>
		public override bool Equals(object? obj)
		{
			// Check for null and compare run-time types.
			// https://learn.microsoft.com/ru-ru/dotnet/api/system.object.equals?view=net-7.0
			if ((obj is null) || !GetType().Equals(obj.GetType()))
			{
				throw new ArgumentException("Сравнивать можно только с вектором");
			}

			Vector vector = (Vector)obj;

			if (Dimensions != vector.Dimensions)
			{
				throw new ArgumentException("Сравнивать можно только одинаковые по размеру вектора");
			}

			Vector diff = this - vector;

			float length = 0;
			for (int i = 0; i < Dimensions; i++)
			{
				length += diff[i, 0] * diff[i, 0];
			}

			return length < Epsilon;
		}
	}
}
