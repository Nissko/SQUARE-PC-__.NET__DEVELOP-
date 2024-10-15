using AutoMapper;
using squarePC.Application.Common.Interfaces;
using squarePC.Application.Common.Mapping.Cpus;

namespace squarePC.Application.Common.Mapping
{
    public class CustomMapper : ICustomMapper
    {
        private readonly CpuMapperProfile _cpuMapperProfile;
        private readonly IMapper _autoMapper;
        
        public CustomMapper(IMapper autoMapper)
        {
            _autoMapper = autoMapper;
            _cpuMapperProfile = new CpuMapperProfile();
        }

        public CpuMapperProfile CpuMapperProfile => _cpuMapperProfile;
        public IMapper AutoMapper => _autoMapper;
    }
}