using squarePC.Domain.Common;
using squarePC.Domain.Exceptions.CpuExceptions;

namespace squarePC.Domain.Enums.CpuEnums
{
    /// <summary>
    /// Тип поддерживаемой памяти процессором
    /// </summary>
    public class CpuMemoryTypeEnum : Enumeration
    {
        #region Конструктор, исключения

        public CpuMemoryTypeEnum(Guid id, string name)
            : base(id, name)
        {
        }

        public static IEnumerable<CpuMemoryTypeEnum> List() =>
            new[]
            {
                DDR4,
                DDR5,
            };

        public static CpuMemoryTypeEnum FromName(string cpuSocketName)
        {
            var request = List()
                .SingleOrDefault(s => string.Equals(s.Name, cpuSocketName, StringComparison.CurrentCultureIgnoreCase));

            if (request == null)
            {
                var cpuMemoryAvailable = string.Join(",", List().Select(s => s.Name));
                
                throw new CpuMemoryTypeException(errorCpuMemory: cpuSocketName, message: cpuMemoryAvailable);
            }

            return request;
        }

        public static string From(Guid cpuSocketId)
        {
            var request = List().SingleOrDefault(s => s.Id == cpuSocketId);

            if (request == null)
            {
                var cpuMemoryAvailable = string.Join(",", List().Select(s => s.Id));
                
                throw new CpuMemoryTypeException(errorCpuMemory: cpuSocketId.ToString(), message: cpuMemoryAvailable);
            }

            return request.ToString();
        }

        #endregion
        
        public static CpuMemoryTypeEnum DDR4 = new CpuMemoryTypeEnum(Guid.Parse("E4689125-CA3E-4B07-AC23-9F8ACD88844B"),
            nameof(DDR4).ToLowerInvariant());
    
        public static CpuMemoryTypeEnum DDR5 = new CpuMemoryTypeEnum(Guid.Parse("5D60F162-61CE-4F04-A2CC-D7DAE9CC53FB"),
            nameof(DDR5).ToLowerInvariant());
    }
}