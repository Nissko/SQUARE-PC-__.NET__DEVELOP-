using MediatR;
using squarePC.Application.Application.Interfaces.Cpu;
using squarePC.Application.DTO.Cpu;

namespace squarePC.Application.Application.Commands.Cpus
{
    public class UpdateCpuCommandHandler : IRequestHandler<UpdateCpuCommand, Unit>
    {
        private readonly ICpuRepository _cpuRepository;

        public UpdateCpuCommandHandler(ICpuRepository cpuRepository)
        {
            _cpuRepository = cpuRepository?? throw new ArgumentNullException(nameof(cpuRepository));
        }

        public async Task<Unit> Handle(UpdateCpuCommand request, CancellationToken cancellationToken)
        {
            var updateCpuRequestDto = await ConstructCpuDTO(request);
            
            await _cpuRepository.UpdateCpuDetailsAsync(updateCpuRequestDto, cancellationToken);
            
            return Unit.Value;
        }

        private static async Task<CpuDto> ConstructCpuDTO(UpdateCpuCommand request)
        {
            var dto = new CpuDto()
            {
                CpuId = request.UpdateCpu.cpuId,
                Price = request.UpdateCpu.price,
                Count = request.UpdateCpu.count,
                MainInfo = new CpuMainInfoDto()
                {
                    FamilyCpuId = request.UpdateCpu.mainInfo.FamilyCpuId,
                    Model = request.UpdateCpu.mainInfo.Model,
                    SocketId = request.UpdateCpu.mainInfo.SocketId,
                    ReleaseDate = request.UpdateCpu.mainInfo.ReleaseDate,
                    Warranty = request.UpdateCpu.mainInfo.Warranty,
                    CodeManufacture = request.UpdateCpu.mainInfo.CodeManufacture
                },
                CoreAndArchitecture = new CpuCoreAndArchitectureDto()
                {
                    CacheL2 = request.UpdateCpu.coreAndArchitecture.cacheL2,
                    CacheL3 = request.UpdateCpu.coreAndArchitecture.cacheL3,
                    CoreName = request.UpdateCpu.coreAndArchitecture.coreName,
                    ECore = request.UpdateCpu.coreAndArchitecture.eCore,
                    PCore = request.UpdateCpu.coreAndArchitecture.pCore,
                    TechnoProcess = request.UpdateCpu.coreAndArchitecture.technoProcess,
                    Virtualization = request.UpdateCpu.coreAndArchitecture.virtualization
                },
                ClocksAndOc = new CpuClocksAndOcDto
                {
                    BaseClock = request.UpdateCpu.clocksAndOc.baseClock,
                    TurboClock = request.UpdateCpu.clocksAndOc.turboClock,
                    BaseClockECore = request.UpdateCpu.clocksAndOc.baseClockECore,
                    TurboClockECore = request.UpdateCpu.clocksAndOc.turboClockECore,
                    FreeMultiplier = request.UpdateCpu.clocksAndOc.freeMultiplier
                },
                Tdp = new CpuTdpDto
                {
                    Tdp = request.UpdateCpu.tdp.Tdp,
                    BaseTdp = request.UpdateCpu.tdp.BaseTdp,
                    MaxTempCpu = request.UpdateCpu.tdp.MaxTempCpu
                },
                Ram = new CpuRamDto
                {
                    MemoryTypeId = request.UpdateCpu.ram.MemoryTypeId,
                    MaxValueMemory = request.UpdateCpu.ram.MaxValueMemory,
                    MaxChannelMemory = request.UpdateCpu.ram.MaxChannelMemory,
                    ClockMemory = request.UpdateCpu.ram.ClockMemory,
                    SupportEcc = request.UpdateCpu.ram.SupportEcc
                },
                BusAndController = new CpuBusAndControllerDto
                {
                    PciExpressControllerVersion = request.UpdateCpu.busAndController.PciExpressControllerVersion,
                    CountLinesPciExpress = request.UpdateCpu.busAndController.CountLinesPciExpress
                },
                GpuCore = new CpuGpuCoreDto
                {
                    HasGpuCore = request.UpdateCpu.gpuCore.hasGpuCore,
                    CpuModelGraphCore = request.UpdateCpu.gpuCore.cpuModelGraphCore,
                    CpuMaxClockGraphCore = request.UpdateCpu.gpuCore.cpuMaxClockGraphCore,
                    CpuGraphBlocks = request.UpdateCpu.gpuCore.cpuGraphBlocks,
                    CpuShadingUnits = request.UpdateCpu.gpuCore.cpuShadingUnits
                }
            };
            
            return dto;
        }
    }
}