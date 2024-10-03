namespace squarePC.Domain.Exceptions.CpuExceptions
{
    public class CpuSocketEnumException : Exception
    {
        public CpuSocketEnumException()
        { }

        public CpuSocketEnumException(string errorSocker, string message)
            : base()
        {
            throw new Exception($"Сокет {errorSocker} не найден." +
                                $"Возможные значения: {message}");
        }
    }
}