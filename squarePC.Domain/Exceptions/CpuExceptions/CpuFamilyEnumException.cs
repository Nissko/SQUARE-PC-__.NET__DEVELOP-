namespace squarePC.Domain.Exceptions.CpuExceptions
{
    public class CpuFamilyEnumException : Exception
    {
        public CpuFamilyEnumException()
        { }

        public CpuFamilyEnumException(string errorCpu, string message)
            : base()
        {
            throw new Exception($"Cемейство процессоров {errorCpu} не найдено." +
                                $"Возможные значения для семейства процессора {message}");
        }
    }
}

