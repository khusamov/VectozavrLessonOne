using SFML.Graphics;
using SFML.Window;

namespace VectozavrLessonOne
{
	internal class SfmlExample
	{
		public static void DisplayExampleWindow()
		{
			RenderWindow window = new RenderWindow(new VideoMode(1000, 500), "Вектозавр Урок #1", Styles.Close);
			window.SetFramerateLimit(60);
			window.KeyPressed += OnKeyPressed;
			window.Closed += OnClosed;
			while (window.IsOpen)
			{
				window.DispatchEvents();
				window.Clear(Color.White);
				window.Display();
			}
		}

		private static void OnKeyPressed(object? sender, KeyEventArgs e)
		{
			if (sender is not null)
			{
				Window window = (Window)sender;
				if (e.Code == Keyboard.Key.Escape)
				{
					window.Close();
				}
			}
		}

		private static void OnClosed(object? sender, EventArgs e)
		{
			if (sender is not null)
			{
				Window window = (Window)sender;
				window.Close();
			}
		}
	}
}
