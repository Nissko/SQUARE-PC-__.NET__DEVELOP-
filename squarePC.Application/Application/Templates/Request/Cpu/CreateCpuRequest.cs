using squarePC.Application.Application.Models.Cpus.Create;

namespace squarePC.Application.Application.Templates.Request.Cpu
{
    public record CreateCpuRequest
    (
        int count,
        decimal price,
        CpuMainInfoItem mainInfo,
        CpuCoreAndArchitectureItem coreAndArchitecture,
        CpuClocksAndOcItem clocksAndOc,
        CpuTdpItem tdp,
        CpuRamItem ram,
        CpuBusAndControllersItem busAndController,
        CpuGpuCoreItem gpuCore
    );
}