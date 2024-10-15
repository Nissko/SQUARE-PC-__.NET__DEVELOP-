using squarePC.Application.Common.Interfaces;
using squarePC.Application.DTO.Cpu;
using squarePC.Domain.Aggregates.CpuAggregate;

namespace squarePC.Application.Common.Mapping.Cpus
{
    public class CpuMapperProfile : IMapperProfile
    {
        public CpuDto GetCpuDto(CpuEntity cpu)
        {
            return new CpuDto
            {
                CpuId = cpu.Id,
                Price = cpu.Price,
                Count = cpu.CpuCount,
                MainInfo = new CpuMainInfoDto()
                {
                    FamilyCpuId = cpu.CpuMainInfo.CpuFamily.Id,
                    Model = cpu.CpuMainInfo.CpuModel,
                    SocketId = cpu.CpuMainInfo.CpuSocket.Id,
                    ReleaseDate = cpu.CpuMainInfo.CpuReleaseDate,
                    Warranty = cpu.CpuMainInfo.CpuWarranty,
                    CodeManufacture = cpu.CpuMainInfo.CpuManufacture
                },
                CoreAndArchitecture = new CpuCoreAndArchitectureDto()
                {
                    CacheL2 = cpu.CpuCoreAndArchitecture.CpuCacheL2,
                    CacheL3 = cpu.CpuCoreAndArchitecture.CpuCacheL3,
                    CoreName = cpu.CpuCoreAndArchitecture.CpuCoreName,
                    ECore = cpu.CpuCoreAndArchitecture.CpuECores,
                    PCore = cpu.CpuCoreAndArchitecture.CpuPCores,
                    TechnoProcess = cpu.CpuCoreAndArchitecture.CpuTechnoProcess,
                    Virtualization = cpu.CpuCoreAndArchitecture.CpuVirtualisation
                },
                ClocksAndOc = new CpuClocksAndOcDto
                {
                    BaseClock = cpu.CpuClocksAndOc.CpuBaseClock,
                    TurboClock = cpu.CpuClocksAndOc.CpuTurboClock,
                    BaseClockECore = cpu.CpuClocksAndOc.CpuBaseClockECore,
                    TurboClockECore = cpu.CpuClocksAndOc.CpuTurboClockECore,
                    FreeMultiplier = cpu.CpuClocksAndOc.CpuFreeMultiplier
                },
                Tdp = new CpuTdpDto
                {
                    Tdp = cpu.CpuTdp.TDP,
                    BaseTdp = cpu.CpuTdp.BaseTDP,
                    MaxTempCpu = cpu.CpuTdp.MaxTempCPU,
                },
                Ram = new CpuRamDto
                {
                    MemoryTypeId = cpu.CpuRam.MemoryType.Id,
                    MaxValueMemory = cpu.CpuRam.MaxValueMemory,
                    MaxChannelMemory = cpu.CpuRam.MaxChannelMemory,
                    ClockMemory = cpu.CpuRam.ClockMemory,
                    SupportEcc = cpu.CpuRam.SupportECC
                },
                BusAndController = new CpuBusAndControllerDto
                {
                    PciExpressControllerVersion = cpu.CpuBusAndController.PciExpressControllerVersion,
                    CountLinesPciExpress = cpu.CpuBusAndController.CountLinesPciExpress
                },
                GpuCore = new CpuGpuCoreDto
                {
                    HasGpuCore = cpu.CpuGpuCore.CpuHasGpuCore,
                    CpuModelGraphCore = cpu.CpuGpuCore.CpuModelGraphCore,
                    CpuMaxClockGraphCore = cpu.CpuGpuCore.CpuMaxClockGraphCore,
                    CpuGraphBlocks = cpu.CpuGpuCore.CpuGraphBlocks.ToString(),
                    CpuShadingUnits = cpu.CpuGpuCore.CpuShadingUnits.ToString()
                }
            };
        }
    }
}