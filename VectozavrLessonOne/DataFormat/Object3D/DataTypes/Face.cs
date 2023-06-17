using VectozavrLessonOne.Engine;
using VectozavrLessonOne.Algebra.Vector;
using SFML.Graphics;
using VectozavrLessonOne.DataFormat.Object3D.ParsingStateItems;

namespace VectozavrLessonOne.DataFormat.Object3D.DataTypes
{
    /// <summary>
    /// Грань (а точнее треугольник).
    /// f 3 11 10
    /// </summary>
    internal class Face : DataTypeParser
	{
		public override string TypeName => "f";

		public override void DefineState(ParsingState parsingState)
		{
			parsingState.DefineItem(new TriangleCollection());
			parsingState.DefineItem(new VertexCollection());
			parsingState.DefineItem(new GroupColor());
		}

		public override ParsingState Parse(ParsingState parsingState, ObjectLineModel lineParts)
		{
			List<Triangle> triangleCollection = parsingState.GetItem<List<Triangle>>("TriangleCollection");
			List<Vector> vertexCollection = parsingState.GetItem<List<Vector>>("VertexCollection");
			Color groupColor = parsingState.GetItem<Color>("GroupColor");

			// Внимание, индексы вершин, хранящиеся в OBJ-файле, начинаются с 1, а не с нуля.
			int vertexIndex1 = Convert.ToInt32(lineParts[0]) - 1;
			int vertexIndex2 = Convert.ToInt32(lineParts[1]) - 1;
			int vertexIndex3 = Convert.ToInt32(lineParts[2]) - 1;

			triangleCollection.Add(
				 new Triangle(
					  vertexCollection[vertexIndex1],
					  vertexCollection[vertexIndex2],
					  vertexCollection[vertexIndex3],
					  groupColor
				 )
			);

			return parsingState;
		}
	}
}
