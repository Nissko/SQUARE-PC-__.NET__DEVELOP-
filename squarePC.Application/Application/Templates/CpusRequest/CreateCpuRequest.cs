using squarePC.Application.Application.Models.Cpus.Create;

namespace squarePC.Application.Application.Templates.CpusRequest
{
    public record CreateCpuRequest(
        int cpuCount,
        decimal price,
        CpuMainInfoItem cpuMainInfo,
        CpuCoreAndArchitectureItem cpuCoreAndArchitecture,
        CpuClocksAndOcItem CpuClocksAndOc,
        CpuTdpItem cpuTdp,
        CpuRamItem cpuRam,
        CpuBusAndControllersItem cpuBusAndController,
        CpuGpuCoreItem cpuGpuCore
    );
}