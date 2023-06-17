using VectozavrLessonOne.Engine;

namespace VectozavrLessonOne.DataFormat.Object3D
{
    /// <summary>
    /// Парсер OBJ-файлов.
    /// </summary>
    /// <see cref="https://ru.wikipedia.org/wiki/Obj"/>
    /// <see cref="http://www.martinreddy.net/gfx/3d/OBJ.spec"/>
    /// <see cref="https://github.com/vectozavr/learn_3dzavr/blob/master/engine/utils/ResourceManager.cpp"/>
    internal class Parser
	{
		private DataTypeParserCollection _dataTypeParserCollection;
		private ParsingState _parsingState = new();

		/// <summary>
		/// Конструктор парсера.
		/// </summary>
		/// <param name="dataTypeParserCollection">Массив парсеров типов данных, которые будет обрабатывать парсер</param>
		public Parser(DataTypeParserCollection dataTypeParserCollection)
		{
			_dataTypeParserCollection = dataTypeParserCollection;
			foreach (DataTypeParser dataType in dataTypeParserCollection.AsArray)
			{
				dataType.DefineState(_parsingState);
			}
		}

		/// <summary>
		/// Парсинг текстового файла (представленного как массив строк) 
		/// в словарь массивов треугольников.
		/// </summary>
		/// <param name="data">Содержимое OBJ-файла в виде массива строк (UTF-8)</param>
		/// <returns></returns>
		public Dictionary<string, Triangle[]> Parse(string[] data)
		{
			foreach (string line in data)
			{
				ObjectLineModel lineParts = new(line);

				DataTypeParser? dataTypeParser = _dataTypeParserCollection[lineParts.DataTypeName];

				if (dataTypeParser is null)
				{
					continue;
				}

				_parsingState = dataTypeParser.Parse(_parsingState, lineParts);
			}

			return _parsingState.GetItem<Dictionary<string, Triangle[]>>("Objects");
		}
	}
}
