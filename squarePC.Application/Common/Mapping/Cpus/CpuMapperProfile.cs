using squarePC.Application.Common.Interfaces;
using squarePC.Application.DTO.Cpu;
using CpuEntity = squarePC.Domain.Aggregates.CpuAggregate.CpuEntity;

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
                FamilyCpuId = cpu.CpuFamily.Id,
                Model = cpu.CpuModel,
                SocketId = cpu.CpuSocket.Id,
                CodeManufacture = cpu.CpuManufacture,
                ReleaseDate = cpu.CpuReleaseDate,
                Warranty = cpu.CpuWarranty,
                PCores = cpu.CpuPCores,
                ECores = cpu.CpuECores,
                CacheL2 = cpu.CpuCacheL2,
                CacheL3 = cpu.CpuCacheL3,
                TechnoProcess = cpu.CpuTechnoProcess,
                CoreName = cpu.CpuCoreName,
                Virtualization = cpu.CpuVirtualisation,
                BaseClock = cpu.CpuBaseClock,
                TurboClock = cpu.CpuTurboClock,
                BaseClockECore = cpu.CpuBaseClockECore,
                TurboClockECore = cpu.CpuTurboClockECore,
                FreeMultiplier = cpu.CpuFreeMultiplier,
                Tdp = cpu.Tdp,
                BaseTdp = cpu.BaseTdp,
                MaxTempCpu = cpu.MaxTempCpu,
                MemoryTypeId = cpu.MemoryType.Id,
                MaxValueMemory = cpu.MaxValueMemory,
                MaxChannelMemory = cpu.MaxChannelMemory,
                ClockMemory = cpu.ClockMemory,
                SupportEcc = cpu.SupportECC,
                PciExpressControllerVersion = cpu.PciExpressControllerVersion,
                CountLinesPciExpress = cpu.CountLinesPciExpress,
                HasGpuCore = cpu.CpuHasGpuCore,
                CpuModelGraphCore = cpu.CpuModelGraphCore,
                CpuMaxClockGraphCore = cpu.CpuMaxClockGraphCore,
                CpuGraphBlocks = cpu.CpuGraphBlocks,
                CpuShadingUnits = cpu.CpuShadingUnits
            };
        }
    }
}