using SFML.Graphics;

namespace VectozavrLessonOne.DataFormat.Object3D.ParsingStateItems
{
    /// <summary>
    /// Цвет группы треугольников.
    /// При появлении типа данных "g" цвет должен смениться.
    /// </summary>
    internal class GroupColor : ParsingStateItem<Color>
	{
		public GroupColor(Color? defaultColor = null) : base(defaultColor ?? new(255, 245, 194, 255)) {}

		public override string Name => "GroupColor";
	}
}
