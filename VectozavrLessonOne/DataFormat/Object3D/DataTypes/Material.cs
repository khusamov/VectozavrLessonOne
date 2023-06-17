using SFML.Graphics;
using VectozavrLessonOne.DataFormat.Object3D.ParsingStateItems;

namespace VectozavrLessonOne.DataFormat.Object3D.DataTypes
{
    /// <summary>
    /// Материал (а точнее цвет).
    /// m 003 77 77 77 255
    /// </summary>
    internal class Material : DataTypeParser
	{
		public override string TypeName => "m";

		public override void DefineState(ParsingState parsingState)
		{
			parsingState.DefineItem(new ColorCollection());
		}

		public override ParsingState Parse(ParsingState parsingState, ObjectLineModel lineParts)
		{
			string colorName = lineParts[0];
			byte red = Convert.ToByte(lineParts[1]);
			byte green = Convert.ToByte(lineParts[2]);
			byte blue = Convert.ToByte(lineParts[3]);
			byte alpha = Convert.ToByte(lineParts[4]);

			Dictionary<string, Color> colorCollection = parsingState.GetItem<Dictionary<string, Color>>("ColorCollection");
			colorCollection.Add(colorName, new Color(red, green, blue, alpha));

			return parsingState;
		}
	}
}
