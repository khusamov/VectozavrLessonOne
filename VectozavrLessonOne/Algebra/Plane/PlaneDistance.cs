using AlgebraVector = VectozavrLessonOne.Algebra.Vector.Vector;

namespace VectozavrLessonOne.Algebra.Plane
{
	public partial class Plane
	{
		/// <summary>
		/// Расстояние от плоскости до точки.
		/// 
		/// Есть две стороны плоскости:
		/// - прямая сторона плоскости это туда куда смотрит вектор нормали,
		/// - обратная сторона.
		/// 
		/// Если расстояние больше или равно нулю, то точка находится с прямой стороны плоскости. И наоборот.
		/// </summary>
		/// <param name="point">Тестируемая точка</param>
		/// <see cref="https://github.com/vectozavr/3dzavr/blob/master/engine/math/Plane.cpp#L13"/>
		/// <returns></returns>
		public float Distance(AlgebraVector point)
		{
			return point.Dot(_normal) - _point.Dot(_normal);
		}
	}
}
