namespace VectozavrLessonOne.DataFormat.Object3D.ParsingStateItems
{
    /// <summary>
    /// Имя текущего объекта.
    /// При появлении типа данных "o" имя должно смениться.
    /// </summary>
    internal class ObjectName : ParsingStateItem<string>
	{
		public ObjectName(string objectName = "Untitled") : base(objectName) {}

		public override string Name => "ObjectName";
	}
}
