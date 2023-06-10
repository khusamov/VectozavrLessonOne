using VectozavrLessonOne.Algebra.Vector;

namespace VectozavrLessonOne.Engine
{
	/// <summary>
	/// Константы движка.
	/// </summary>
	/// <see cref="https://github.com/vectozavr/learn_3dzavr/blob/master/engine/Consts.h"/>
	internal class Consts
	{
		public static readonly int STANDARD_SCREEN_WIDTH = 1920;
		public static readonly int STANDARD_SCREEN_HEIGHT = 1080;
		public static readonly SFML.Graphics.Color BACKGROUND_COLOR = new SFML.Graphics.Color(255, 255, 255);
		public static readonly string PROJECT_NAME = "engine";
		public static readonly bool USE_LOG_FILE = true;
		public static readonly bool USE_OPEN_GL = false;
		public static readonly bool SHOW_DEBUG_INFO = false;
		public static readonly bool SHOW_FPS_COUNTER = false;

		public static readonly double EPA_EPS = 0.0001;

		public static readonly double RAY_CAST_MAX_DISTANCE = 10000;

		public static readonly string THIN_FONT = "engine/fonts/Roboto-Thin.ttf";
		public static readonly string MEDIUM_FONT = "engine/fonts/Roboto-Medium.ttf";

		public static readonly double LARGEST_TIME_STEP = 1.0 / 15.0;
		public static readonly double TAP_DELAY = 0.2;

		public static readonly Vector[] BEZIER = { new Vector(new float[] {0.8f, 0f}), new Vector(new float[] {0.2f, 0f})};

		public static readonly uint NETWORK_VERSION = 3U;
		public static readonly int NETWORK_TIMEOUT = 5;
		public static readonly int NETWORK_WORLD_UPDATE_RATE = 30;
		public static readonly double NETWORK_RELIABLE_RETRY_TIME = 1.0 / 20;
		public static readonly uint NETWORK_MAX_CLIENTS = 64;
	}
}
