using squarePC.Application.Application.Models.Cpus.Create;

namespace squarePC.Application.Application.Templates.Request.Cpu
{
    public record UpdateCpuRequest
    (
        Guid cpuId,
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