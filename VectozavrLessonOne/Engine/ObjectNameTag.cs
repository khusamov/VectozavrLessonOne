namespace VectozavrLessonOne.Engine
{
	/// <summary>
	/// Странный класс. По сути можно было бы использовать вместо него просто string.
	/// </summary>
	internal class ObjectNameTag
	{
		private readonly string _name = "";

		public ObjectNameTag(string name)
		{
			_name = name;
		}

		public string Name
		{
			get => _name;
		}

		public bool Contains(ObjectNameTag tag) => _name.Contains(tag.Name);
		public static bool operator ==(ObjectNameTag a, ObjectNameTag b) => a.Name.Equals(b.Name);
		public static bool operator !=(ObjectNameTag a, ObjectNameTag b) => !(a.Name.Equals(b.Name));
		public static bool operator <(ObjectNameTag a, ObjectNameTag b) => a.Name.Length < b.Name.Length;
		public static bool operator >(ObjectNameTag a, ObjectNameTag b) => a.Name.Length > b.Name.Length;

		public override int GetHashCode() => Name.GetHashCode();

		public override bool Equals(object? obj)
		{
			return base.Equals(obj);
		}
	}
}
