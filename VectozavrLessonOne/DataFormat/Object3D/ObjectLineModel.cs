namespace VectozavrLessonOne.DataFormat.Object3D
{
	/// <summary>
	/// Данные одной строки из OBJ-файла.
	/// Считается что в строке записываются части через пробел.
	/// Первая часть это имя типа данных, а остальные части это значения для этого типа данных.
	/// Например "v 0.044140 0.012938 -0.190583". Здесь "v" тип данных "Вершина", а числа это координаты этой вершины.
	/// </summary>
	internal class ObjectLineModel
	{
		private readonly string _dataTypeName;
		private readonly string[] _dataTypeParams;

		/// <summary>
		/// Имя типа данных.
		/// </summary>
		public string DataTypeName => _dataTypeName;

		/// <summary>
		/// Массив значений типа данных.
		/// </summary>
		public string[] DataTypeParams => _dataTypeParams;

		/// <summary>
		/// Конструктор объекта строки данных.
		/// </summary>
		/// <param name="line">Строка из OBJ-файла</param>
		public ObjectLineModel(string line)
		{
			string[] lineParts = line.Split("");
			_dataTypeName = lineParts[0];
			_dataTypeParams = lineParts[1..];
		}

		/// <summary>
		/// Получение значений значений через их индекс.
		/// Например чтобы получить координату Y для вершины 
		/// из строки "v 0.044140 0.012938 -0.190583" нужно написать LinePartCollection[1].
		/// </summary>
		/// <param name="paramIndex">Индекс значения</param>
		/// <returns></returns>
		public string this[int paramIndex]
		{
			get => _dataTypeParams[paramIndex];
		}
	}
}
