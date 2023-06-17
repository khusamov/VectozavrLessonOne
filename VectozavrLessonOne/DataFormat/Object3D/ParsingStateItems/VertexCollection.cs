using VectozavrLessonOne.Algebra.Vector;

namespace VectozavrLessonOne.DataFormat.Object3D.ParsingStateItems
{
    /// <summary>
    /// Список вершин. 
    /// Он общий для всего OBJ-файла.
    /// </summary>
    internal class VertexCollection : ParsingStateItem<List<Vector>>
	{
		public VertexCollection() : base(new()) {}

		public override string Name => "VertexCollection";
	}
}
