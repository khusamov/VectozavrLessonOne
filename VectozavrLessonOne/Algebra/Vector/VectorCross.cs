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
			if (Dimensions > 3 || vector.Dimensions > 3)
			{
				throw new ArgumentException("Размеры векторов должны быть не более трех");
			}

			Vector ToVector3(Vector vector)
			{
				switch (vector.Dimensions)
				{
					case 1: return new Vector(new float[] { vector.X, 0, 0 });
					case 2: return new Vector(new float[] { vector.X, vector.Y, 0 });
					case 3: return vector;
				}
				throw new ArgumentException("Размер вектора должен быть от 1 до 3");
			}

			Vector left = ToVector3(this);
			Vector right = ToVector3(vector);

			return new Vector(
				new float[] {
					left.Y * right.Z - right.Y * left.Z,
					left.Z * right.X - right.Z * left.X,
					left.X * right.Y - right.X * left.Y
				}
			);
		}
	}
}
