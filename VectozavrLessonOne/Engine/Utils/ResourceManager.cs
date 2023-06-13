using SFML.Audio;
using SFML.Graphics;
using System.Diagnostics;

namespace VectozavrLessonOne.Engine.Utils
{
	/// <summary>
	/// Менеджер ресурсов: текстуры, шрифты, звуки и трехмерные объекты.
	/// </summary>
	/// <see cref="https://github.com/vectozavr/learn_3dzavr/blob/master/engine/utils/ResourceManager.h"/>
	/// <see cref="https://github.com/vectozavr/learn_3dzavr/blob/master/engine/utils/ResourceManager.cpp"/>
	internal class ResourceManager
	{
		private readonly Dictionary<string, Texture> _textures = new();
		private readonly Dictionary<string, Font> _fonts = new();
		private readonly Dictionary<string, SoundBuffer> _soundBuffers = new();
		private readonly Dictionary<string, List<Mesh>> _objects = new();

		private static ResourceManager? _instance;

		private static void UnloadObjects() 
		{

		}

		private static void UnloadTextures()
		{

		}

		private static void UnloadSoundBuffers() 
		{

		}

		private static void UnloadFonts() 
		{

		}

		public static void UnloadAllResources()
		{

		}

		public static void Init()
		{
			_instance = new ResourceManager();
			Debug.WriteLine("ResourceManager.Init(): ResourceManager был инициализирован.");
		}

		public static void Free()
		{

		}

		public static List<Mesh> LoadObjects(string filename)
		{
			return new();
		}

		public static Texture LoadTexture(string filename)
		{
			return new(0, 0);
		}

		public static Font LoadFont(string filename)
		{
			return new("");
		}

		public static SoundBuffer LoadSoundBuffer(string filename)
		{
			return new("");
		}
	}
}
