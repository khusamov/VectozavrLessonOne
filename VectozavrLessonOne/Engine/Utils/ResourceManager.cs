using SFML.Audio;
using SFML.Graphics;
using System.Diagnostics;
using Object3DParser = VectozavrLessonOne.DataFormat.Object3D.Parser;
using Object3DDataTypeParser = VectozavrLessonOne.DataFormat.Object3D.DataTypeParser;
using Object3DDataTypeParserCollection = VectozavrLessonOne.DataFormat.Object3D.DataTypeParserCollection;

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
		private readonly Dictionary<string, Mesh[]> _objects = new();

		private static ResourceManager? _instance;

		/// <summary>
		/// Конструктор приватный, потому что ResourceManager построен по шаблону Singleton.
		/// </summary>
		private ResourceManager()
		{

		}

		private static void UnloadObjects() 
		{
			if (_instance is null)
			{
				return;
			}
			_instance._objects.Clear();
		}

		private static void UnloadTextures()
		{
			if (_instance is null)
			{
				return;
			}
			_instance._textures.Clear();
		}

		private static void UnloadSoundBuffers() 
		{
			if (_instance is null)
			{
				return;
			}
			_instance._soundBuffers.Clear();
		}

		private static void UnloadFonts() 
		{
			if (_instance is null)
			{
				return;
			}
			_instance._fonts.Clear();
		}

		public static void UnloadAllResources()
		{
			UnloadTextures();
			UnloadSoundBuffers();
			UnloadFonts();
			UnloadObjects();
			Debug.WriteLine("ResourceManager.UnloadAllResources(): Все ресурсы выгружены.");
		}

		public static void Init()
		{
			_instance = new ResourceManager();
			Debug.WriteLine("ResourceManager.Init(): ResourceManager был инициализирован.");
		}

		public static void Free()
		{
			UnloadAllResources();
			_instance = null;
		}

		public static Mesh[] LoadObjects(string filename)
		{
			if (_instance is null)
			{
				return Array.Empty<Mesh>();
			}

			string[] object3dLines = File.ReadAllLines(filename);
			Object3DParser object3dParser = new(
				new Object3DDataTypeParserCollection(
					new Object3DDataTypeParser[] {
						// TODO Добавить парсеры типов данных OBJ-файла.
					}
				)
			);
			var triangleGroupsDictionary = object3dParser.Parse(object3dLines);
			Mesh[] objects = new Mesh[triangleGroupsDictionary.Count];

			int i = 0;
			foreach ((string triangleGroupName, var triangleGroup) in triangleGroupsDictionary)
			{
				objects[i] = new Mesh(new ObjectNameTag(triangleGroupName), triangleGroup);
				i++;
			}

			_instance._objects.Add(filename, objects);

			return objects;
		}

		public static Texture? LoadTexture(string filename)
		{
			if (_instance is null)
			{
				return null;
			}

			if (_instance._textures.ContainsKey(filename))
			{
				return _instance._textures[filename];
			}

			Texture texture = new(filename);

			Debug.WriteLine($"ResourceManager.LoadTexture(): Текстура загружена '{filename}'.");

			texture.Repeated = true;
			_instance._textures.Add(filename, texture);

			return texture;
		}

		public static Font? LoadFont(string filename)
		{
			if (_instance is null)
			{
				return null;
			}

			if (_instance._fonts.ContainsKey(filename)) 
			{ 
				return _instance._fonts[filename]; 
			}

			Font font = new(filename);

			Debug.WriteLine($"ResourceManager.LoadFont(): Шрифт загружен '{filename}'.");

			_instance._fonts.Add(filename, font);

			return font;
		}

		public static SoundBuffer? LoadSoundBuffer(string filename)
		{
			if (_instance is null)
			{
				return null;
			}

			if (_instance._soundBuffers.ContainsKey(filename))
			{
				return _instance._soundBuffers[filename];
			}

			SoundBuffer soundBuffer = new(filename);

			Debug.WriteLine($"ResourceManager.LoadSoundBuffer(): Звук загружен '{filename}'.");

			_instance._soundBuffers.Add(filename, soundBuffer);

			return soundBuffer;
		}
	}
}
