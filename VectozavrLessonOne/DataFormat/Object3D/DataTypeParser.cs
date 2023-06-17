namespace VectozavrLessonOne.DataFormat.Object3D
{
    internal abstract class DataTypeParser
    {
        public abstract string TypeName
        {
            get;
        }

        public abstract void DefineState(ParsingState parsingState);

        public abstract ParsingState Parse(ParsingState parsingState, ObjectLineModel lineParts);
    }
}
