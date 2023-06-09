namespace VectozavrLessonOne.Algebra.Vector
{
	public partial class Vector
	{
		public float this[int row]
		{
			get => this[row, 0];
			set => this[row, 0] = value;
		}
	}
}
