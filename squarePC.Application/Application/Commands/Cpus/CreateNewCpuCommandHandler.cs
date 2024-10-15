using MediatR;
using squarePC.Application.Application.Interfaces.Cpu;
using squarePC.Application.Common.Interfaces;
using squarePC.Application.DTO.Cpu;

namespace squarePC.Application.Application.Commands.Cpus
{
    public class CreateNewCpuCommandHandler : IRequestHandler<CreateNewCpuCommand>
    {
        private readonly ICpuRepository _repository;

        public CreateNewCpuCommandHandler(ICpuRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<Unit> Handle(CreateNewCpuCommand request, CancellationToken cancellationToken)
        {
            var cpuDto = await ConstructCpuDTO(request);

            await _repository.CreateCpuAsync(cpuDto, cancellationToken);
            
            return Unit.Value;
        }

        private static async Task<CpuDto> ConstructCpuDTO(CreateNewCpuCommand request)
        {
            var dto = new CpuDto()
            {
                Price = request.CreateCpu.price,
                Count = request.CreateCpu.count,
                MainInfo = new CpuMainInfoDto()
                {
                    FamilyCpuId = request.CreateCpu.mainInfo.FamilyCpuId,
                    Model = request.CreateCpu.mainInfo.Model,
                    SocketId = request.CreateCpu.mainInfo.SocketId,
                    ReleaseDate = request.CreateCpu.mainInfo.ReleaseDate,
                    Warranty = request.CreateCpu.mainInfo.Warranty,
                    CodeManufacture = request.CreateCpu.mainInfo.CodeManufacture
                },
                CoreAndArchitecture = new CpuCoreAndArchitectureDto()
                {
                    CacheL2 = request.CreateCpu.coreAndArchitecture.cacheL2,
                    CacheL3 = request.CreateCpu.coreAndArchitecture.cacheL3,
                    CoreName = request.CreateCpu.coreAndArchitecture.coreName,
                    ECore = request.CreateCpu.coreAndArchitecture.eCore,
                    PCore = request.CreateCpu.coreAndArchitecture.pCore,
                    TechnoProcess = request.CreateCpu.coreAndArchitecture.technoProcess.ToString(),
                    Virtualization = request.CreateCpu.coreAndArchitecture.virtualization.ToString()
                },
                ClocksAndOc = new CpuClocksAndOcDto
                {
                    BaseClock = request.CreateCpu.clocksAndOc.baseClock.ToString(),
                    TurboClock = request.CreateCpu.clocksAndOc.turboClock.ToString(),
                    BaseClockECore = request.CreateCpu.clocksAndOc.baseClockECore.ToString(),
                    TurboClockECore = request.CreateCpu.clocksAndOc.turboClockECore.ToString(),
                    FreeMultiplier = request.CreateCpu.clocksAndOc.freeMultiplier.ToString()
                },
                Tdp = new CpuTdpDto
                {
                    Tdp = request.CreateCpu.tdp.Tdp.ToString(),
                    BaseTdp = request.CreateCpu.tdp.BaseTdp.ToString(),
                    MaxTempCpu = request.CreateCpu.tdp.MaxTempCpu.ToString()
                },
                Ram = new CpuRamDto
                {
                    MemoryTypeId = request.CreateCpu.ram.MemoryTypeId,
                    MaxValueMemory = request.CreateCpu.ram.MaxValueMemory.ToString(),
                    MaxChannelMemory = request.CreateCpu.ram.MaxChannelMemory.ToString(),
                    ClockMemory = request.CreateCpu.ram.ClockMemory.ToString(),
                    SupportEcc = request.CreateCpu.ram.SupportEcc.ToString()
                },
                BusAndController = new CpuBusAndControllerDto
                {
                    PciExpressControllerVersion = request.CreateCpu.busAndController.PciExpressControllerVersion,
                    CountLinesPciExpress = request.CreateCpu.busAndController.CountLinesPciExpress
                },
                GpuCore = new CpuGpuCoreDto
                {
                    HasGpuCore = request.CreateCpu.gpuCore.hasGpuCore.ToString(),
                    CpuModelGraphCore = request.CreateCpu.gpuCore.cpuModelGraphCore,
                    CpuMaxClockGraphCore = request.CreateCpu.gpuCore.cpuMaxClockGraphCore.ToString(),
                    CpuGraphBlocks = request.CreateCpu.gpuCore.cpuGraphBlocks.ToString(),
                    CpuShadingUnits = request.CreateCpu.gpuCore.cpuShadingUnits.ToString()
                }
            };
            
            return dto;
        }
    }
}