using System.Diagnostics;

namespace VectozavrLessonOne.Engine.Utils
{
	/// <summary>
	/// Коллекция таймеров (секундомеров).
	/// Счетчик FPS.
	/// Время в тиках со старта программы.
	/// </summary>
	/// <see cref="https://github.com/vectozavr/learn_3dzavr/blob/master/engine/utils/Time.h"/>
	/// <see cref="https://github.com/vectozavr/learn_3dzavr/blob/master/engine/utils/Time.cpp"/>
	internal class Time
	{
		private readonly Dictionary<string, Timer> timers = new();
		private DateTime start = DateTime.Now;
		private DateTime last = new();

		#region Счетчик FPS.
		private DateTime fpsStart = new();
		private int fpsCountTime = 1000; // Миллисекунды. В исходном коде было std::chrono::milliseconds.
		private int fpsCounter = 0;
		private double lastFps = 0.0d;
		#endregion

		#region Compatibility.
		private double time = 0;
		private double deltaTime = 0;
		#endregion

		public static Time? instance;

		public Time()
		{
			last = start;
		}

		public static void Init()
		{
			instance = new Time();
			Debug.WriteLine("Time.Init(): Time было инициализировано.");
		}

		public static void Free()
		{
			instance = null;
			Debug.WriteLine("Time.Init(): Time было уничтожено.");
		}

		public static int Fps()
		{
			if (instance is null)
			{
				return 0;
			}
			return (int)instance.lastFps;
		}
		
		/// <summary>
		/// Время работы программы с начала запуска.
		/// Измеряется в тиках.
		/// </summary>
		/// <returns></returns>
		public static double TimeValue()
		{
			if (instance is null)
			{
				return 0;
			}
			return instance.time;
		}

		public static double DeltaTime()
		{
			if (instance is null)
			{
				return 0;
			}
			return instance.deltaTime;
		}

		public static void Update()
		{
			if (instance is null)
			{
				return;
			}
			DateTime t = DateTime.Now;

			instance.deltaTime = t.Ticks - instance.last.Ticks;
			instance.time = t.Ticks - instance.start.Ticks;
			// В случае, когда fps < 10, полезно уменьшить deltaTime (чтобы избежать проблем с коллизиями).
			if (instance.deltaTime > Consts.LARGEST_TIME_STEP)
			{
				instance.deltaTime = Consts.LARGEST_TIME_STEP;
			}

			instance.last = t;

			if (instance.deltaTime > 10)
			{
				return;
			}

			instance.fpsCounter++;
			if (t.Millisecond - instance.fpsStart.Millisecond > instance.fpsCountTime)
			{
				instance.lastFps = instance.fpsCounter / (t.Ticks - instance.fpsStart.Ticks);
				instance.fpsCounter = 0;
				instance.fpsStart = t;
			}
		}

		public static void StartTimer(string timerName)
		{
			if (instance is null)
			{
				return;
			}
			instance.timers.Add(timerName, new Timer());
			instance.timers[timerName].Start();
		}

		public static void StopTimer(string timerName)
		{
			if (instance is null)
			{
				return;
			}
			if (instance.timers.ContainsKey(timerName))
			{
				instance.timers[timerName].Stop();
			}
		}

		public static int ElapsedTimerMilliseconds(string timerName)
		{
			if (instance is null)
			{
				return 0;
			}
			if (instance.timers.ContainsKey(timerName))
			{
				return instance.timers[timerName].ElapsedMilliseconds;
			}
			return 0;
		}

		public static int ElapsedTimerSeconds(string timerName)
		{
			if (instance is null)
			{
				return 0;
			}
			if (instance.timers.ContainsKey(timerName))
			{
				return instance.timers[timerName].ElapsedSeconds;
			}
			return 0;
		}

		public static Dictionary<string, Timer> Timers()
		{
			if (instance is null)
			{
				return new();
			}
			return instance.timers;
		}
	}
}
