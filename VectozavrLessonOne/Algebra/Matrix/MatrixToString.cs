namespace VectozavrLessonOne.Algebra.Matrix
{
	public partial class Matrix
	{
		public override string ToString()
		{
			if (Cols == 0 && Rows == 0) return "Пустая матрица";

			string result = "{ {";

			for (int i = 0; i < Rows; i++)
			{
				for (int j = 0; j < Cols; j++)
				{
					result += this[i, j];
					if (j < Cols - 1)
					{
						result += ", ";
					}
				}
				if (i < Rows - 1)
				{
					result += "}, {";
				}
			}

			result += "} }";

			return result;
		}
	}
}
