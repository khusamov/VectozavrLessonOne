using VectozavrLessonOne.Engine.Utils;

namespace VectozavrLessonOne.Engine.IO
{
	/// <summary>
	/// Keyboard
	/// </summary>
	/// <see cref="https://github.com/vectozavr/3dzavr/blob/master/engine/io/Keyboard.cpp"/>
	/// <see cref="https://github.com/vectozavr/3dzavr/blob/master/engine/io/Keyboard.h"/>
	internal class Keyboard
	{
		private Dictionary<SFML.Window.Keyboard.Key, double> _tappedKeys = new();

		public static bool IsKeyPressed(SFML.Window.Keyboard.Key key)
		{
			return SFML.Window.Keyboard.IsKeyPressed(key);
			
		}

		public bool IsKeyTapped(SFML.Window.Keyboard.Key key)
		{
			if (!SFML.Window.Keyboard.IsKeyPressed(key))
			{
				return false;
			}

			if (!_tappedKeys.ContainsKey(key))
			{
				_tappedKeys.Add(key, Time.TimeValue());
				return true;
			}
			else if (Time.TimeValue() - _tappedKeys[key] > Consts.TAP_DELAY)
			{
				_tappedKeys[key] = Time.TimeValue();
				return true;
			}
			return false;
		}
	}
}
