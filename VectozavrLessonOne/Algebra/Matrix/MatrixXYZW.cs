using System.Data;
using AlgebraVector = VectozavrLessonOne.Algebra.Vector;

namespace VectozavrLessonOne.Algebra.Matrix
{
	public partial class Matrix
	{
		/// <summary>
		/// Первый столбец из матрицы в виде вектора-столбца.
		/// </summary>
		public AlgebraVector.Vector X
		{
			get
			{
				if (Rows < 4 || Cols < 4)
				{
					throw new ArgumentException("Матрица должна быть как минимум 4 на 4");
				}
				return new(new float[] { this[0, 0], this[1, 0], this[2, 0] });
			}
		}

		/// <summary>
		/// Второй столбец из матрицы в виде вектора-столбца.
		/// </summary>
		public AlgebraVector.Vector Y
		{
			get
			{
				if (Rows < 4 || Cols < 4)
				{
					throw new ArgumentException("Матрица должна быть как минимум 4 на 4");
				}
				return new(new float[] { this[0, 1], this[1, 1], this[2, 1] });
			}
		}

		/// <summary>
		/// Третий столбец из матрицы в виде вектора-столбца.
		/// </summary>
		public AlgebraVector.Vector Z
		{
			get
			{
				if (Rows < 4 || Cols < 4)
				{
					throw new ArgumentException("Матрица должна быть как минимум 4 на 4");
				}
				return new(new float[] { this[0, 2], this[1, 2], this[2, 2] });
			}
		}

		/// <summary>
		/// Четвертый столбец из матрицы в виде вектора-столбца.
		/// </summary>
		public AlgebraVector.Vector W
		{
			get
			{
				if (Rows < 4 || Cols < 4)
				{
					throw new ArgumentException("Матрица должна быть как минимум 4 на 4");
				}
				return new(new float[] { this[0, 3], this[1, 3], this[2, 3] });
			}
		}
	}
}
