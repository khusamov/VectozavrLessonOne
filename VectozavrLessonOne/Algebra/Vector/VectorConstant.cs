using VectozavrLessonOne.Algebra.Matrix;

namespace VectozavrLessonOne.Algebra.Vector
{
	public partial class Vector
	{
		/// <summary>
		/// �������� ������� � ����� ��������� �� ���� ��� �����������.
		/// </summary>
		/// <param name="rows">���������� ����� � ����� �������</param>
		/// <param name="constantValue">�������� ������</param>
		/// <returns>������</returns>
		public static Vector Constant(int rows, float constantValue)
		{
			return FromMatrix(Constant(new MatrixSize(rows, 1), constantValue));
		}
	}
}
