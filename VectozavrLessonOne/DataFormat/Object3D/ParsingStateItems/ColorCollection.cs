using SFML.Graphics;

namespace VectozavrLessonOne.DataFormat.Object3D.ParsingStateItems
{
    internal class ColorCollection : ParsingStateItem<Dictionary<string, Color>>
	{
		public ColorCollection() : base(new()) {}

		public override string Name => "ColorCollection";
	}
}
