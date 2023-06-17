namespace VectozavrLessonOne.DataFormat.Object3D
{
    /// <summary>
    /// Элемент состояния парсера OBJ-файлов.
    /// Служит для хранения каких-то данных типа T, появляющихся во время парсинга.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal abstract class ParsingStateItem<T>
    {
        /// <summary>
        /// Значение по умолчанию.
        /// </summary>
        protected T _defaultValue;

        /// <summary>
        /// Имя элемента состояния парсера.
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Значение по умолчанию.
        /// </summary>
        public virtual T DefaultValue => _defaultValue;

        /// <summary>
        /// Конструктор элемента состояния парсера OBJ-файлов.
        /// </summary>
        /// <param name="defaultValue">Значение по умолчанию</param>
        public ParsingStateItem(T defaultValue)
        {
            _defaultValue = defaultValue;
        }
    }
}
