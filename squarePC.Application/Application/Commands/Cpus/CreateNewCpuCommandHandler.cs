using MediatR;
using squarePC.Application.Application.Templates.CpusRequest;
using squarePC.Application.Common.Interfaces;
using squarePC.Domain.Aggregates.CpuAggregate;

namespace squarePC.Application.Application.Commands.Cpus
{
    public class CreateNewCpuCommandHandler : IRequestHandler<CreateNewCpuCommand, Unit>
    {
        private readonly ISquarePcContext _context;
        private readonly IMediator _mediator;

        public CreateNewCpuCommandHandler(ISquarePcContext context, IMediator mediator)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
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
                cpuCount: cpuRequest.cpuCount,
                cpuMainInfo: new CpuMainInfoEntity(
                    familyCpuId: cpuRequest.cpuMainInfo.FamilyCpuId,
                    model: cpuRequest.cpuMainInfo.Model,
                    socketId: cpuRequest.cpuMainInfo.SocketId,
                    codeManufacture: cpuRequest.cpuMainInfo.CodeManufacture,
                    releaseDate: cpuRequest.cpuMainInfo.ReleaseDate,
                    warranty: cpuRequest.cpuMainInfo.Warranty
                ),
                cpuCoreAndArchitecture: new CpuCoreAndArchitectureEntity(
                    pCores: cpuRequest.cpuCoreAndArchitecture.pCore,
                    eCores: cpuRequest.cpuCoreAndArchitecture.eCore,
                    cacheL2: cpuRequest.cpuCoreAndArchitecture.cacheL2,
                    cacheL3: cpuRequest.cpuCoreAndArchitecture.cacheL3,
                    technoProcess: cpuRequest.cpuCoreAndArchitecture.technoProcess,
                    coreName: cpuRequest.cpuCoreAndArchitecture.coreName,
                    virtualization: cpuRequest.cpuCoreAndArchitecture.virtualization
                ),
                cpuClocksAndOc: new CpuClocksAndOcEntity(
                    baseClock: cpuRequest.CpuClocksAndOc.baseClock,
                    turboClock: cpuRequest.CpuClocksAndOc.turboClock,
                    baseClockECore: cpuRequest.CpuClocksAndOc.baseClockECore,
                    turboClockECore: cpuRequest.CpuClocksAndOc.turboClockECore,
                    freeMultiplier: cpuRequest.CpuClocksAndOc.freeMultiplier
                ),
                cpuTdp: new CpuTdpInfoEntity(
                    tdp: cpuRequest.cpuTdp.Tdp,
                    baseTdp: cpuRequest.cpuTdp.BaseTdp,
                    maxTempCpu: cpuRequest.cpuTdp.MaxTempCpu
                ),
                cpuRam: new CpuRamInfoEntity(
                    memoryTypeId: cpuRequest.cpuRam.MemoryTypeId,
                    maxValueMemory: cpuRequest.cpuRam.MaxValueMemory,
                    maxChannelMemory: cpuRequest.cpuRam.MaxChannelMemory,
                    clockMemory: cpuRequest.cpuRam.ClockMemory,
                    supportEcc: cpuRequest.cpuRam.SupportEcc
                ),
                cpuBusAndController: new CpuBusAndControllersEntity(
                    pciExpressControllerVersion: cpuRequest.cpuBusAndController.PciExpressControllerVersion,
                    countLinesPciExpress: cpuRequest.cpuBusAndController.CountLinesPciExpress
                ),
                cpuGpuCore: new CpuGpuCoreInfoEntity(
                    hasGpuCore: cpuRequest.cpuGpuCore.hasGpuCore,
                    cpuModelGraphCore: cpuRequest.cpuGpuCore.cpuModelGraphCore,
                    cpuMaxClockGraphCore: cpuRequest.cpuGpuCore.cpuMaxClockGraphCore,
                    cpuGraphBlocks: cpuRequest.cpuGpuCore.cpuGraphBlocks,
                    cpuShadingUnits: cpuRequest.cpuGpuCore.cpuShadingUnits
                )
            );


            return cpuEntity;
        }
    }
}