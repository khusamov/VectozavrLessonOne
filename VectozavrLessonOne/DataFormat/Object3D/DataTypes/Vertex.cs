using VectozavrLessonOne.Algebra.Vector;
using VectozavrLessonOne.DataFormat.Object3D.ParsingStateItems;

namespace VectozavrLessonOne.DataFormat.Object3D.DataTypes
{
    /// <summary>
    /// Вершина.
    /// v 0.044140 0.012938 -0.190583
    /// </summary>
    internal class Vertex : DataTypeParser
	{
		public override string TypeName => "v";

		public override void DefineState(ParsingState parsingState)
		{
			parsingState.DefineItem(new VertexCollection());
		}

		public override ParsingState Parse(ParsingState parsingState, ObjectLineModel lineParts)
		{
			float x = Convert.ToSingle(lineParts[0]);
			float y = Convert.ToSingle(lineParts[1]);
			float z = Convert.ToSingle(lineParts[2]);

			List<Vector> vertexCollection = parsingState.GetItem<List<Vector>>("VertexCollection");
			vertexCollection.Add(new Vector(new float[] { x, y, z }));

			return parsingState;
		}
	}
}
