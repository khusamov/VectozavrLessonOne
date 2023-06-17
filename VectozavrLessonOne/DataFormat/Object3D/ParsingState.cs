namespace VectozavrLessonOne.DataFormat.Object3D
{
    /// <summary>
    /// Хранение значений элементов состояния парсинга.
    /// Получение и изменение значений элементов состояния парсинга.
    /// </summary>
    internal class ParsingState
	{
		/// <summary>
		/// Словарь значений элементов состояния парсинга с именами элементов.
		/// </summary>
		private readonly Dictionary<string, object> _parsingStateItemValues = new();

		/// <summary>
		/// Определить элемент состояния парсинга.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="parsingStateItem"></param>
		/// <exception cref="ArgumentException"></exception>
		public void DefineItem<T>(ParsingStateItem<T> parsingStateItem)
		{
			string itemName = parsingStateItem.Name;
			if (!_parsingStateItemValues.ContainsKey(itemName))
			{
				T value = parsingStateItem.DefaultValue ?? throw new ArgumentException("Значение не должно быть равно null");
				_parsingStateItemValues.Add(itemName, value);
			}
		}

		/// <summary>
		/// Получить значение элемента состояния по его имени.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="itemName"></param>
		/// <returns></returns>
		/// <exception cref="KeyNotFoundException"></exception>
		public T GetItem<T>(string itemName)
		{
			if (!_parsingStateItemValues.ContainsKey(itemName))
			{
				throw new KeyNotFoundException($"Не найден элемент состояния парсинга '{itemName}'");
			}
			return (T)_parsingStateItemValues[itemName];
		}

		/// <summary>
		/// Установить новое значение элемента состояния по его имени.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="itemName"></param>
		/// <param name="value"></param>
		/// <exception cref="ArgumentException"></exception>
		public void SetItem<T>(string itemName, T value)
		{
			if (value is null)
			{
				throw new ArgumentException("Значение не должно быть равно null");
			}
			_parsingStateItemValues.Add(itemName, value);
		}
	}
}
