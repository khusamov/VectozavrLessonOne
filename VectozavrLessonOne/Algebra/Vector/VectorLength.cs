namespace VectozavrLessonOne.Algebra.Vector
{
	public partial class Vector
	{
		/// <summary>
		/// Длина (модуль) вектора.
		/// </summary>
		/// <see cref="https://bit.ly/3WYhE9n"/>
		public float Length
		{
			get
			{
				float result = 0.0f;

				for (int row = 0; row < Rows; row++)
				{
					result += this[row] * this[row];
				}
				
				return (float)Math.Sqrt(result);
			}
		}
	}
}
