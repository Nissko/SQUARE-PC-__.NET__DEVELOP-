using squarePC.Domain.Common;
using squarePC.Domain.Exceptions.CpuExceptions;

namespace squarePC.Domain.Enums.CpuEnums
{
    /// <summary>
    /// Справочник семейств процессоров 
    /// </summary>
    public class CpuFamilyEnum : Enumeration
    {
        #region Конструктор, исключения

        public CpuFamilyEnum(Guid id, string name)
            : base(id, name)
        {
        }

        public static IEnumerable<CpuFamilyEnum> List() =>
            new[]
            {
                /*AMD*/
                Ryzen3,
                Ryzen5,
                Ryzen7,
                Ryzen9,
                RyzenThreadripper,
                /*Intel*/
                Core3,
                Core5,
                Core7,
                Core9
            };

        public static CpuFamilyEnum FromName(string cpuFamilyName)
        {
            var request = List()
                .SingleOrDefault(s => string.Equals(s.Name, cpuFamilyName, StringComparison.CurrentCultureIgnoreCase));

            if (request == null)
            {
                var cpuFamilyAvailable = string.Join(",", List().Select(s => s.Name));
                
                throw new CpuFamilyEnumException(errorCpu: cpuFamilyName, message: cpuFamilyAvailable);
            }

            return request;
        }

        public static string From(Guid cpuFamilyId)
        {
            var request = List().SingleOrDefault(s => s.Id == cpuFamilyId);

            if (request == null)
            {
                var cpuFamilyAvailable = string.Join(",", List().Select(s => s.Id));
                
                throw new CpuFamilyEnumException(errorCpu: cpuFamilyId.ToString(), message: cpuFamilyAvailable);
            }

            return request.ToString();
        }

        #endregion
        
        #region AMD
        
        public static CpuFamilyEnum Ryzen3 = new CpuFamilyEnum(Guid.Parse("98AF8330-C0F7-4B37-A948-11E1FF3DE035"),
            "Ryzen 3".ToLowerInvariant());
        
        public static CpuFamilyEnum Ryzen5 = new CpuFamilyEnum(Guid.Parse("B40E36D9-2118-4FA8-8CD0-D2CADD067D77"),
            "Ryzen 5".ToLowerInvariant());
        
        public static CpuFamilyEnum Ryzen7 = new CpuFamilyEnum(Guid.Parse("7DC5F4A3-30BF-46F0-87AB-195690F60F2F"),
            "Ryzen 7".ToLowerInvariant());
        
        public static CpuFamilyEnum Ryzen9 = new CpuFamilyEnum(Guid.Parse("F3DB9A45-81D2-4A6B-B04D-CC5B7CA045BE"),
            "Ryzen 9".ToLowerInvariant());
        
        public static CpuFamilyEnum RyzenThreadripper = new CpuFamilyEnum(Guid.Parse("06C1BEE5-DBD0-4EF1-9B0E-564AC4E378AA"),
            "Ryzen Threadripper".ToLowerInvariant());
            
        #endregion

        #region Intel

        public static CpuFamilyEnum Core3 = new CpuFamilyEnum(Guid.Parse("DB7F2EFD-D0C0-4F48-826F-8347DAED4256"),
            "Core I3".ToLowerInvariant());
        
        public static CpuFamilyEnum Core5 = new CpuFamilyEnum(Guid.Parse("379A6E77-5549-4869-899E-146E7EB97152"),
            "Core I5".ToLowerInvariant());
        
        public static CpuFamilyEnum Core7 = new CpuFamilyEnum(Guid.Parse("9C56B7FC-DDF4-41B5-BD23-B97A539BA8D3"),
            "Core I7".ToLowerInvariant());
        
        public static CpuFamilyEnum Core9 = new CpuFamilyEnum(Guid.Parse("326DD069-6513-4D29-9487-7F4233C7E4F5"),
            "Core I9".ToLowerInvariant());

        #endregion
    }
}

