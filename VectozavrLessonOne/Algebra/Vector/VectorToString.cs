namespace VectozavrLessonOne.Algebra.Vector
{
	public partial class Vector
	{
		public override string ToString()
		{
			if (Cols == 0 && Rows == 0) return "Пустой вектор";

			string result = "{";

			for (int i = 0; i < Rows; i++)
			{
				result += this[i, 0];
				if (i < Rows - 1)
				{
					result += ", ";
				}
			}

			result += "}";

			return result;
		}
	}
}
