namespace VectozavrLessonOne.Algebra.Matrix
{
	public partial class Matrix
	{
		/// <summary>
		/// �������� ������� � ����� ��������� �� ���� �������.
		/// </summary>
		/// <param name="size">������� ����� �������</param>
		/// <param name="constantValue">�������� ������</param>
		/// <returns>�������</returns>
		public static Matrix Constant(MatrixSize size, float constantValue)
		{
			Matrix result = new(new float[size.Rows, size.Cols]);

			for (int row = 0; row < size.Rows; row++)
			{
				for (int col = 0; col < size.Cols; col++)
				{
					result[row, col] = constantValue;
				}
			}

			return result;
		}
	}
}
