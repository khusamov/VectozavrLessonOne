using SFML.Graphics;
using VectozavrLessonOne.DataFormat.Object3D.ParsingStateItems;

namespace VectozavrLessonOne.DataFormat.Object3D.DataTypes
{
    /// <summary>
    /// Группа треугольников (одного цвета). По сути это смена текущего цвета.
    /// g Cube.001_Cube.014_Material.002
    /// </summary>
    internal class Group : DataTypeParser
	{
		public override string TypeName => "g";

		public override void DefineState(ParsingState parsingState)
		{
			parsingState.DefineItem(new GroupColor());
			parsingState.DefineItem(new ColorCollection());
		}

		public override ParsingState Parse(ParsingState parsingState, ObjectLineModel lineParts)
		{
			string nextColorName = lineParts[0].Substring(lineParts[0].Length - 3);
			Dictionary<string, Color> colorCollection = parsingState.GetItem<Dictionary<string, Color>>("ColorCollection");
			parsingState.SetItem("GroupColor", colorCollection[nextColorName]);

			return parsingState;
		}
	}
}
