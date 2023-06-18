namespace VectozavrLessonOne.Algebra.Plane
{
	public partial class Plane
	{
		public Plane Clone() => new(_normal, _point);
	}
}
