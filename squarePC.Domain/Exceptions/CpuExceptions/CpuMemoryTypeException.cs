namespace squarePC.Domain.Exceptions.CpuExceptions
{
    public class CpuMemoryTypeException : Exception
    {
        public CpuMemoryTypeException()
        { }
        
        public CpuMemoryTypeException(string errorCpuMemory, string message)
            : base()
        {
            throw new Exception($"Тип памяти {errorCpuMemory} не найден." +
                                $"Возможные типы памяти - {message}");
        }
    }
}