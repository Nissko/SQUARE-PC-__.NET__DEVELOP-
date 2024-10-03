using squarePC.Domain.Common;
using squarePC.Domain.Exceptions.CpuExceptions;

namespace squarePC.Domain.Aggregates.ConfigurationAggregate;

public class CpuSocketEnum : Enumeration
{
    #region Конструктор, исключения

        public CpuSocketEnum(Guid id, string name)
            : base(id, name)
        {
        }

        public static IEnumerable<CpuSocketEnum> List() =>
            new[]
            {
                /*AMD*/
                AMD4,
                AM5,
                /*Intel*/
                LGA1700,
                LGA1200,
                LGA1151v2
            };

        public static CpuSocketEnum FromName(string cpuSocketName)
        {
            var request = List()
                .SingleOrDefault(s => string.Equals(s.Name, cpuSocketName, StringComparison.CurrentCultureIgnoreCase));

            if (request == null)
            {
                var cpuSocketAvailable = string.Join(",", List().Select(s => s.Name));
                
                throw new CpuSocketEnumException(errorSocker: cpuSocketName, message: cpuSocketAvailable);
            }

            return request;
        }

        public static string From(Guid cpuSocketId)
        {
            var request = List().SingleOrDefault(s => s.Id == cpuSocketId);

            if (request == null)
            {
                var cpuSocketAvailable = string.Join(",", List().Select(s => s.Id));
                
                throw new CpuSocketEnumException(errorSocker: cpuSocketId.ToString(), message: cpuSocketAvailable);
            }

            return request.ToString();
        }

        #endregion
        
    #region Сокеты AMD
    
    public static CpuSocketEnum AMD4 = new CpuSocketEnum(Guid.Parse("3CEF7D97-FB57-4386-A107-9C0997634B11"),
        nameof(AMD4).ToLowerInvariant());
    
    public static CpuSocketEnum AM5 = new CpuSocketEnum(Guid.Parse("AE4C7B42-D6D3-4BD6-AD4C-0AADB197C614"),
        nameof(AM5).ToLowerInvariant());
        
    #endregion
    
    #region Сокеты Intel
    
    public static CpuSocketEnum LGA1700 = new CpuSocketEnum(Guid.Parse("3CC3993F-E3DE-4081-8DA2-BA3F303B9EA0"),
        "LGA 1700".ToLowerInvariant());
    
    public static CpuSocketEnum LGA1200 = new CpuSocketEnum(Guid.Parse("1284B103-DDB1-4146-B571-EFDD874DB9D2"),
        "LGA 1200".ToLowerInvariant());
    
    public static CpuSocketEnum LGA1151v2 = new CpuSocketEnum(Guid.Parse("CC011285-1129-4367-BA69-455229C7A0E4"),
        "LGA 1151-v2".ToLowerInvariant());
        
    #endregion
}