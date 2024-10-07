using MediatR;
using squarePC.Application.Application.Templates.Request.Cpu;
using squarePC.Application.Common.Interfaces;
using squarePC.Domain.Aggregates.CpuAggregate;

namespace squarePC.Application.Application.Commands.Cpus
{
    public class CreateNewCpuCommandHandler : IRequestHandler<CreateNewCpuCommand, Unit>
    {
        private readonly ISquarePcContext _context;

        public CreateNewCpuCommandHandler(ISquarePcContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Unit> Handle(CreateNewCpuCommand request, CancellationToken cancellationToken)
        {
            var cpuRequest = request.CreateCpu;
            
            var newCpu = await AddNewCpu(cpuRequest);
            
            await _context.Cpus.AddAsync(newCpu, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

        private async Task<CpuEntity> AddNewCpu(CreateCpuRequest cpuRequest)
        {
            var cpuEntity = new CpuEntity(
                cpuPrice: cpuRequest.price,
                cpuCount: cpuRequest.count,
                cpuMainInfo: new CpuMainInfoEntity(
                    familyCpuId: cpuRequest.mainInfo.FamilyCpuId,
                    model: cpuRequest.mainInfo.Model,
                    socketId: cpuRequest.mainInfo.SocketId,
                    codeManufacture: cpuRequest.mainInfo.CodeManufacture,
                    releaseDate: cpuRequest.mainInfo.ReleaseDate,
                    warranty: cpuRequest.mainInfo.Warranty
                ),
                cpuCoreAndArchitecture: new CpuCoreAndArchitectureEntity(
                    pCores: cpuRequest.coreAndArchitecture.pCore,
                    eCores: cpuRequest.coreAndArchitecture.eCore,
                    cacheL2: cpuRequest.coreAndArchitecture.cacheL2,
                    cacheL3: cpuRequest.coreAndArchitecture.cacheL3,
                    technoProcess: cpuRequest.coreAndArchitecture.technoProcess,
                    coreName: cpuRequest.coreAndArchitecture.coreName,
                    virtualization: cpuRequest.coreAndArchitecture.virtualization
                ),
                cpuClocksAndOc: new CpuClocksAndOcEntity(
                    baseClock: cpuRequest.clocksAndOc.baseClock,
                    turboClock: cpuRequest.clocksAndOc.turboClock,
                    baseClockECore: cpuRequest.clocksAndOc.baseClockECore,
                    turboClockECore: cpuRequest.clocksAndOc.turboClockECore,
                    freeMultiplier: cpuRequest.clocksAndOc.freeMultiplier
                ),
                cpuTdp: new CpuTdpInfoEntity(
                    tdp: cpuRequest.tdp.Tdp,
                    baseTdp: cpuRequest.tdp.BaseTdp,
                    maxTempCpu: cpuRequest.tdp.MaxTempCpu
                ),
                cpuRam: new CpuRamInfoEntity(
                    memoryTypeId: cpuRequest.ram.MemoryTypeId,
                    maxValueMemory: cpuRequest.ram.MaxValueMemory,
                    maxChannelMemory: cpuRequest.ram.MaxChannelMemory,
                    clockMemory: cpuRequest.ram.ClockMemory,
                    supportEcc: cpuRequest.ram.SupportEcc
                ),
                cpuBusAndController: new CpuBusAndControllersEntity(
                    pciExpressControllerVersion: cpuRequest.busAndController.PciExpressControllerVersion,
                    countLinesPciExpress: cpuRequest.busAndController.CountLinesPciExpress
                ),
                cpuGpuCore: new CpuGpuCoreInfoEntity(
                    hasGpuCore: cpuRequest.gpuCore.hasGpuCore,
                    cpuModelGraphCore: cpuRequest.gpuCore.cpuModelGraphCore,
                    cpuMaxClockGraphCore: cpuRequest.gpuCore.cpuMaxClockGraphCore,
                    cpuGraphBlocks: cpuRequest.gpuCore.cpuGraphBlocks,
                    cpuShadingUnits: cpuRequest.gpuCore.cpuShadingUnits
                )
            );


            return cpuEntity;
        }
    }
}