using VectozavrLessonOne.DataFormat.Object3D.ParsingStateItems;
using VectozavrLessonOne.Engine;

namespace VectozavrLessonOne.DataFormat.Object3D.DataTypes
{
    /// <summary>
    /// Объект.
    /// o Cube.002_Cube.015
    /// </summary>
    internal class Object : DataTypeParser
	{
		public override string TypeName => "o";

		public override void DefineState(ParsingState parsingState)
		{
			parsingState.DefineItem(new TriangleCollection());
			parsingState.DefineItem(new ObjectCollection());
			parsingState.DefineItem(new ObjectName());
		}

		public override ParsingState Parse(ParsingState parsingState, ObjectLineModel lineParts)
		{
			string objectName = parsingState.GetItem<string>("ObjectName");
			List<Triangle> triangleCollection = parsingState.GetItem<List<Triangle>>("TriangleCollection");
			Dictionary<string, Triangle[]> objectCollection = parsingState.GetItem<Dictionary<string, Triangle[]>>("ObjectCollection");

			if (triangleCollection.Count != 0)
			{
				objectCollection.Add(objectName, triangleCollection.ToArray());
				triangleCollection.Clear();
			}
			parsingState.SetItem<string>("ObjectName", lineParts[0]);

			return parsingState;
		}
	}
}
