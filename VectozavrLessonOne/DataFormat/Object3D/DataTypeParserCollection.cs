namespace VectozavrLessonOne.DataFormat.Object3D
{
	/// <summary>
	/// Массив парсеров типов данных, 
	/// которые будут в итоге доступны парсеру OBJ-файла.
	/// </summary>
    internal class DataTypeParserCollection
	{
		private DataTypeParser[] _dataTypes = Array.Empty<DataTypeParser>();

		public DataTypeParserCollection(DataTypeParser[] dataTypes)
		{
			_dataTypes = dataTypes;
		}

		public DataTypeParser? this[string name] => GetDataTypeParser(name);

		public DataTypeParser[] AsArray => _dataTypes;

		/// <summary>
		/// Найти парсер типа данных по его имени.
		/// </summary>
		/// <param name="dataTypes">Массив парсеров типов данных</param>
		/// <param name="typeName">Имя типа данных</param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"></exception>
		private DataTypeParser? GetDataTypeParser(string typeName)
		{
			DataTypeParser[] foundDataTypes = _dataTypes.Where(dataType => dataType.TypeName == typeName).ToArray();

			if (foundDataTypes.Length > 1)
			{
				throw new ArgumentException($"Найдено типов данных с именем '{typeName}' больше одной");
			}

			if (foundDataTypes.Length == 0)
			{
				return null;
			}

			return foundDataTypes[0];
		}
	}
}
