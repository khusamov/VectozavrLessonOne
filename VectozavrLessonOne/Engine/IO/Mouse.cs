using SFML.System;
using VectozavrLessonOne.Algebra.Vector;

namespace VectozavrLessonOne.Engine.IO
{
	internal class Mouse
	{
		private Screen _screen;
		private Dictionary<SFML.Window.Mouse.Button, double> _tappedButtons = new();

		public Mouse(Screen screen)
		{
			_screen = screen;
		}

		public static bool IsButtonPressed(SFML.Window.Mouse.Button button)
		{
			return SFML.Window.Mouse.IsButtonPressed(button);
		}

		public bool IsButtonTapped(SFML.Window.Mouse.Button button)
		{
			if (!SFML.Window.Mouse.IsButtonPressed(button))
			{
				return false;
			}

			if (!_tappedButtons.ContainsKey(button))
			{
				_tappedButtons.Add(button, Utils.Time.TimeValue());
				return true;
			}
			else if (Utils.Time.TimeValue() - _tappedButtons[button] > Consts.TAP_DELAY)
			{
				_tappedButtons[button] = Utils.Time.TimeValue();
				return true;
			}
			return false;
		}

		public Vector GetMousePosition()
		{
			var mousePosition = SFML.Window.Mouse.GetPosition(_screen.RenderWindow);
			return new(new float[] { mousePosition.X, mousePosition.Y });
		}

		/// <summary>
		/// Перемещение мышки.
		/// </summary>
		/// <returns></returns>
		public Vector GetMouseDisplacement()
		{
			Vector2i mousePosition = SFML.Window.Mouse.GetPosition(_screen.RenderWindow);
			Vector2i screenCenter = new((int)_screen.Width / 2, (int)_screen.Height / 2);
			Vector2i mouseDisplacement = mousePosition - screenCenter;
			SetMouseInCenter();
			return new Vector(new float[] { mouseDisplacement.X, mouseDisplacement.Y });
		}

		public void SetMouseInCenter()
		{
			Vector2i screenCenter = new((int)_screen.Width / 2, (int)_screen.Height / 2);
			SFML.Window.Mouse.SetPosition(screenCenter, _screen.RenderWindow);
		}
	}
}
