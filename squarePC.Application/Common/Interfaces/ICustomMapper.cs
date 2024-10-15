using AutoMapper;
using squarePC.Application.Common.Mapping.Cpus;

namespace squarePC.Application.Common.Interfaces
{
    public interface ICustomMapper
    {
        CpuMapperProfile CpuMapperProfile { get; }
        IMapper AutoMapper { get; }
    }
}