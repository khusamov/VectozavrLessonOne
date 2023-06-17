using VectozavrLessonOne.Engine;

namespace VectozavrLessonOne.DataFormat.Object3D.ParsingStateItems
{
    /// <summary>
    /// Список треугольников текущего объекта.
    /// Когда в OBJ-файле появится тип данных "o", 
    /// тот этот список сохраняется в списке объектов под своим именем 
    /// и очищается для создания нового списка.
    /// </summary>
    internal class TriangleCollection : ParsingStateItem<List<Triangle>>
	{
		public TriangleCollection() : base(new()) {}

		public override string Name => "TriangleCollection";
	}
}
