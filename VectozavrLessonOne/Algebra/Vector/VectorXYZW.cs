namespace VectozavrLessonOne.Algebra.Vector
{
	public partial class Vector
	{
		/// <summary>
		/// Компонента X вектора.
		/// </summary>
		public new float X
		{
			get => this[0];
			set => this[0] = value;
		}

		/// <summary>
		/// Компонента Y вектора.
		/// </summary>
		public new float Y
		{
			get {
				if (Dimensions < 2)
				{
					throw new IndexOutOfRangeException("Компонента Y не доступна");
				}
				return this[1];
			}
			set
			{
				if (Dimensions < 2)
				{
					throw new IndexOutOfRangeException("Компонента Y не доступна");
				}
				this[1] = value;
			}
		}

		/// <summary>
		/// Компонента Z вектора.
		/// </summary>
		public new float Z
		{
			get
			{
				if (Dimensions < 3)
				{
					throw new IndexOutOfRangeException("Компонента Z не доступна");
				}
				return this[2];
			}
			set
			{
				if (Dimensions < 3)
				{
					throw new IndexOutOfRangeException("Компонента Z не доступна");
				}
				this[2] = value;
			}
		}

		/// <summary>
		/// Компонента W вектора.
		/// </summary>
		public new float W
		{
			get
			{
				if (Dimensions < 4)
				{
					throw new IndexOutOfRangeException("Компонента W не доступна");
				}
				return this[3];
			}
			set
			{
				if (Dimensions < 4)
				{
					throw new IndexOutOfRangeException("Компонента W не доступна");
				}
				this[3] = value;
			}
		}
	}
}
