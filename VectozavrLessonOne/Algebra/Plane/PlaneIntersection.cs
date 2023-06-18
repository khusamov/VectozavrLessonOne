using AlgebraVector = VectozavrLessonOne.Algebra.Vector.Vector;

namespace VectozavrLessonOne.Algebra.Plane
{
	public partial class Plane
	{
		/// <summary>
		/// Vec4D в пространстве, где линия (от "начала" до "конца") 
		/// пересекает плоскость с вектором нормали "_n", а значение "_p" лежит на плоскости
		/// Поиск точки пересечения направленного отрезка (start -> end) с плоскостью.
		/// Также метод возвращает коэффициент (пока не ясно какой). Если он больше нуля, то отрезок 
		/// по направлению наверное совпадает с направлением нормали плоскости.
		/// </summary>
		/// <param name="start"></param>
		/// <param name="end"></param>
		/// <see cref="https://github.com/vectozavr/3dzavr/blob/master/engine/math/Plane.cpp#L17"/>
		/// <see cref="https://vectozavr.ru/lesson.php?id_article=31"/>
		/// <returns></returns>
		public KeyValuePair<AlgebraVector, float> Intersection(AlgebraVector start, AlgebraVector end)
		{
			float startDotNormal = start.Dot(_normal);
			float k = Distance(start) / (startDotNormal - end.Dot(_normal));

			AlgebraVector result = start + (end - start) * k;

			return new KeyValuePair<AlgebraVector, float>(result, k);
		}
	}
}
