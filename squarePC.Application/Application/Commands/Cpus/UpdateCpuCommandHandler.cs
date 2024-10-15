using MediatR;
using squarePC.Application.Application.Interfaces.Cpu;
using squarePC.Application.DTO.Cpu;
using squarePC.Application.Exceptions.CpusApplicationException;

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
            var cpu = await _cpuRepository.GetByIdAsync(request.UpdateCpu.cpuId) ??
                                    throw new CpuNullException(request.UpdateCpu.cpuId);
            
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
                    TechnoProcess = request.UpdateCpu.coreAndArchitecture.technoProcess.ToString(),
                    Virtualization = request.UpdateCpu.coreAndArchitecture.virtualization.ToString()
                },
                ClocksAndOc = new CpuClocksAndOcDto
                {
                    BaseClock = request.UpdateCpu.clocksAndOc.baseClock.ToString(),
                    TurboClock = request.UpdateCpu.clocksAndOc.turboClock.ToString(),
                    BaseClockECore = request.UpdateCpu.clocksAndOc.baseClockECore.ToString(),
                    TurboClockECore = request.UpdateCpu.clocksAndOc.turboClockECore.ToString(),
                    FreeMultiplier = request.UpdateCpu.clocksAndOc.freeMultiplier.ToString()
                },
                Tdp = new CpuTdpDto
                {
                    Tdp = request.UpdateCpu.tdp.Tdp.ToString(),
                    BaseTdp = request.UpdateCpu.tdp.BaseTdp.ToString(),
                    MaxTempCpu = request.UpdateCpu.tdp.MaxTempCpu.ToString()
                },
                Ram = new CpuRamDto
                {
                    MemoryTypeId = request.UpdateCpu.ram.MemoryTypeId,
                    MaxValueMemory = request.UpdateCpu.ram.MaxValueMemory.ToString(),
                    MaxChannelMemory = request.UpdateCpu.ram.MaxChannelMemory.ToString(),
                    ClockMemory = request.UpdateCpu.ram.ClockMemory.ToString(),
                    SupportEcc = request.UpdateCpu.ram.SupportEcc.ToString()
                },
                BusAndController = new CpuBusAndControllerDto
                {
                    PciExpressControllerVersion = request.UpdateCpu.busAndController.PciExpressControllerVersion,
                    CountLinesPciExpress = request.UpdateCpu.busAndController.CountLinesPciExpress
                },
                GpuCore = new CpuGpuCoreDto
                {
                    HasGpuCore = request.UpdateCpu.gpuCore.hasGpuCore.ToString(),
                    CpuModelGraphCore = request.UpdateCpu.gpuCore.cpuModelGraphCore,
                    CpuMaxClockGraphCore = request.UpdateCpu.gpuCore.cpuMaxClockGraphCore.ToString(),
                    CpuGraphBlocks = request.UpdateCpu.gpuCore.cpuGraphBlocks.ToString(),
                    CpuShadingUnits = request.UpdateCpu.gpuCore.cpuShadingUnits.ToString()
                }
            };
            
            return dto;
        }
    }
}