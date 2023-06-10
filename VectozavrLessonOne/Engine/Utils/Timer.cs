namespace VectozavrLessonOne.Engine.Utils
{
	/// <summary>
	/// Таймер.
	/// На самом деле это не таймер, а скорее секундомер. 
	/// Он просто отсчитывает сколько прошло времени с момента запуска.
	/// </summary>
	/// <see cref="https://github.com/vectozavr/learn_3dzavr/blob/master/engine/utils/Timer.h"/>
	/// <see cref="https://github.com/vectozavr/learn_3dzavr/blob/master/engine/utils/Timer.cpp"/>
	internal class Timer
	{
		private DateTime startTime = new();
		private DateTime endTime = new();
		private bool isRunning = false;

		/// <summary>
		/// Запустить таймер.
		/// </summary>
		public void Start()
		{
			startTime = DateTime.Now;
			isRunning = true;
		}

		/// <summary>
		/// Остановить таймер.
		/// </summary>
		public void Stop()
		{
			endTime = DateTime.Now;
			isRunning = false;
		}

		/// <summary>
		/// Получить число секунд с момента запуска таймера.
		/// Если таймер работает, то с момента запуска таймера до текущего момента.
		/// Если таймер выключен, то с момента запуска таймера до момента, когда его выключили.
		/// </summary>
		public int ElapsedSeconds
		{
			get => ElapsedMilliseconds / 1000;
		}

		/// <summary>
		/// Получить число миллисекунд с момента запуска таймера.
		/// Если таймер работает, то с момента запуска таймера до текущего момента.
		/// Если таймер выключен, то с момента запуска таймера до момента, когда его выключили.
		/// </summary>
		public int ElapsedMilliseconds
		{
			get
			{
				DateTime _endTime = isRunning ? DateTime.Now : endTime;
				return _endTime.Millisecond - startTime.Millisecond;
			}
		}
	}
}
