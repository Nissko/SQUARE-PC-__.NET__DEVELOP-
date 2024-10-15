namespace squarePC.Application.Exceptions.CpusApplicationException
{
    public class CpuNullException : Exception
    {
        public CpuNullException() : base()
        { }

        public CpuNullException(Guid cpuNotFoundId)
            : base()
        {
            throw new Exception($"Процессор с идентификатором \"{cpuNotFoundId.ToString()}\" не найден в системе.");
        }
        
        public CpuNullException(string cpuNotFoundId)
            : base(cpuNotFoundId)
        {
            throw new Exception($"Процессор с идентификатором \"{cpuNotFoundId}\" не найден в системе.");
        }
    }
}