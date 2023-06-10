namespace VectozavrLessonOne.Algebra.Vector
{
	public partial class Vector
	{
		/// <summary>
		/// Векторное произведение.
		/// </summary>
		/// <param name="vector"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"></exception>
		public Vector Cross(Vector vector)
		{
			if (Dimensions != 3 || vector.Dimensions != 3)
			{
				throw new ArgumentException("Вектора должны быть трехмерными");
			}

			return new Vector(
				new float[] {
					Y * vector.Z - vector.Y * Z,
					Z * vector.X - vector.Z * X,
					X * vector.Y - vector.X * Y
				}
			);
		}
	}
}
