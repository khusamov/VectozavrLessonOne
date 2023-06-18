using AlgebraVector = VectozavrLessonOne.Algebra.Vector.Vector;

namespace VectozavrLessonOne.Algebra.Plane
{
	/// <summary>
	/// Плоскость. 
	/// Описывается вектором нормали и одной точкой на этой плоскости.
	/// </summary>
	/// <see cref="https://github.com/vectozavr/3dzavr/blob/master/engine/math/Plane.cpp"/>
	/// <see cref="https://github.com/vectozavr/3dzavr/blob/master/engine/math/Plane.h"/>
	public partial class Plane
	{
		private readonly AlgebraVector _normal;
		private readonly AlgebraVector _point;

		/// <summary>
		/// Нормаль плоскости.
		/// </summary>
		public AlgebraVector Normal => _normal;

		/// <summary>
		/// Точка на плоскости.
		/// </summary>
		public AlgebraVector Point => _point;

		/// <summary>
		/// Конструктор плоскости.
		/// </summary>
		/// <param name="normal">Вектор, на основе которого будет сделана нормаль будущей плоскости</param>
		/// <param name="point">Точка на будущей плоскости</param>
		public Plane(AlgebraVector normal, AlgebraVector point)
		{
			_normal = normal.Normalize();
			_point = point;
		}
	}
}
