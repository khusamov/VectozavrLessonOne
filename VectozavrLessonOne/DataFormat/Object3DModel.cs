using VectozavrLessonOne.Engine;

namespace VectozavrLessonOne.DataFormat
{
	/// <summary>
	/// Модель 3D-данных из OBJ-файлов.
	/// </summary>
	/// <see cref="https://ru.wikipedia.org/wiki/Obj"/>
	internal class Object3DModel
	{
		private Dictionary<string, Triangle[]> objects = new();
		private List<Triangle> tris = new();

		public Object3DModel()
		{
			// https://www.programmersought.com/article/48074216032/
			// https://github.com/stefangordon/ObjParser/blob/master/ObjParser/Obj.cs
			// https://learn.microsoft.com/ru-ru/dotnet/api/system.io.file.readalllines?view=net-6.0
			// https://metanit.com/sharp/tutorial/5.3.php

			
		}
	}
}
