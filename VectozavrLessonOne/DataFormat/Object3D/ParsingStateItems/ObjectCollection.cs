using VectozavrLessonOne.Engine;

namespace VectozavrLessonOne.DataFormat.Object3D.ParsingStateItems
{
    /// <summary>
    /// Словарь-массив 3D-объектов из OBJ-файла. 
    /// Каждый объект это именнованный массив треугольников.
    /// Если в OBJ-файле один объект без имени, то его имя будет 
    /// задаваться извне (например имя OBJ-файла).
    /// </summary>
    internal class ObjectCollection : ParsingStateItem<Dictionary<string, Triangle[]>>
	{
		public ObjectCollection() : base(new()) {}

		public override string Name => "ObjectCollection";
	}
}
