using MediatR;
using Microsoft.EntityFrameworkCore;
using squarePC.Application.Common.Interfaces;

namespace squarePC.Application.Application.Commands.Cpus
{
    public class UpdateCpuCommandHandler : IRequestHandler<UpdateCpuCommand, Unit>
    {
        private readonly ISquarePcContext _context;
        private readonly IMediator _mediator;

        public UpdateCpuCommandHandler(ISquarePcContext context, IMediator mediator)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }


        public async Task<Unit> Handle(UpdateCpuCommand request, CancellationToken cancellationToken)
        {
            var updateCpuRequest = request.UpdateCpu;

            var currentCpu = await _context.Cpus.Include(t => t.CpuMainInfo)
                                 .ThenInclude(t => t.CpuFamily)
                                 .Include(t => t.CpuMainInfo)
                                 .ThenInclude(t => t.CpuSocket)
                                 .Include(t => t.CpuCoreAndArchitecture)
                                 .Include(t => t.CpuClocksAndOc)
                                 .Include(t => t.CpuTdp)
                                 .Include(t => t.CpuRam)
                                 .ThenInclude(t => t.MemoryType)
                                 .Include(t => t.CpuBusAndController)
                                 .Include(t => t.CpuGpuCore)
                                 .FirstOrDefaultAsync(cpu => cpu.Id == updateCpuRequest.cpuId) ??
                             throw new ArgumentNullException("Excpetion UpdateCpu");

            currentCpu.UpdateCpu(cpuId: updateCpuRequest.cpuId,
                updatePrice: updateCpuRequest.price,
                updateCount: updateCpuRequest.count,
                familyCpuId: updateCpuRequest.mainInfo.FamilyCpuId,
                modelCpu: updateCpuRequest.mainInfo.Model,
                socketId: updateCpuRequest.mainInfo.SocketId,
                codeManufacture: updateCpuRequest.mainInfo.CodeManufacture,
                releaseDate: updateCpuRequest.mainInfo.ReleaseDate,
                warranty: updateCpuRequest.mainInfo.Warranty,
                updatePCores: updateCpuRequest.coreAndArchitecture.pCore,
                updateECores: updateCpuRequest.coreAndArchitecture.eCore,
                updateCacheL2: updateCpuRequest.coreAndArchitecture.cacheL2,
                updateCacheL3: updateCpuRequest.coreAndArchitecture.cacheL3,
                updateTechnoProcess: updateCpuRequest.coreAndArchitecture.technoProcess,
                updateCoreName: updateCpuRequest.coreAndArchitecture.coreName,
                updateVirtualization: updateCpuRequest.coreAndArchitecture.virtualization,
                updateBaseClock: updateCpuRequest.clocksAndOc.baseClock,
                updateTurboClock: updateCpuRequest.clocksAndOc.turboClock,
                updateBaseClockECore: updateCpuRequest.clocksAndOc.baseClockECore,
                updateTurboClockECore: updateCpuRequest.clocksAndOc.turboClockECore,
                updateFreeMultiplier: updateCpuRequest.clocksAndOc.freeMultiplier,
                updateTdp: updateCpuRequest.tdp.Tdp,
                updateBaseTdp: updateCpuRequest.tdp.BaseTdp,
                updateMaxTempCpu: updateCpuRequest.tdp.MaxTempCpu,
                memoryTypeId: updateCpuRequest.ram.MemoryTypeId,
                maxValueMemory: updateCpuRequest.ram.MaxValueMemory,
                maxChannelMemory: updateCpuRequest.ram.MaxChannelMemory,
                clockMemory: updateCpuRequest.ram.ClockMemory,
                supportEcc: updateCpuRequest.ram.SupportEcc,
                pciExpressControllerVersion: updateCpuRequest.busAndController.PciExpressControllerVersion,
                countLinesPciExpress: updateCpuRequest.busAndController.CountLinesPciExpress,
                hasGpuCore: updateCpuRequest.gpuCore.hasGpuCore,
                cpuModelGraphCore: updateCpuRequest.gpuCore.cpuModelGraphCore,
                cpuMaxClockGraphCore: updateCpuRequest.gpuCore.cpuMaxClockGraphCore,
                cpuGraphBlocks: updateCpuRequest.gpuCore.cpuGraphBlocks,
                cpuShadingUnits: updateCpuRequest.gpuCore.cpuShadingUnits);

            _context.Cpus.Update(currentCpu);
            await _context.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}