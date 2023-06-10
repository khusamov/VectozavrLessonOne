namespace VectozavrLessonOne.Algebra.Matrix
{
	public partial class Matrix
	{
		/// <summary>
		/// �������� ������� � ����� ��������� �� ���� �������.
		/// </summary>
		/// <param name="rows">���������� ����� � ����� �������</param>
		/// <param name="cols">���������� �������� � ����� �������</param>
		/// <param name="constantValue">�������� ������</param>
		/// <returns>�������</returns>
		public static Matrix Constant(int rows, int cols, float constantValue)
		{
			Matrix result = new(new float[rows, cols]);

			for (int row = 0; row < rows; row++)
			{
				for (int col = 0; col < cols; col++)
				{
					result[row, col] = constantValue;
				}
			}

			return result;
		}

		/// <summary>
		/// �������� ���������� ������� � ����� ��������� �� ���� �������.
		/// </summary>
		/// <param name="size">���������� ����� � �������� � ����� �������</param>
		/// <param name="constantValue">�������� ������</param>
		/// <returns></returns>
		public static Matrix Constant(int size, float constantValue) => Constant(size, size, constantValue);
	}
}
