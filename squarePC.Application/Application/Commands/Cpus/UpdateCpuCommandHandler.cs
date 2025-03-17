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
            var updateCpuRequestDto = await ConstructCpuDto(request);
            
            await _cpuRepository.UpdateCpuDetailsAsync(updateCpuRequestDto, cancellationToken);
            
            return Unit.Value;
        }

        private static async Task<CpuDto> ConstructCpuDto(UpdateCpuCommand request)
        {
            var cpuAdd = request.UpdateCpu;
            var dto = new CpuDto
            {
                CpuId = cpuAdd.CpuId,
                Price = cpuAdd.Price,
                Count = cpuAdd.Count,
                FamilyCpuId = cpuAdd.FamilyCpuId,
                Model = cpuAdd.Model,
                SocketId = cpuAdd.SocketId,
                CodeManufacture = cpuAdd.CodeManufacture,
                ReleaseDate = cpuAdd.ReleaseDate,
                Warranty = cpuAdd.Warranty,
                PCores = cpuAdd.PCores,
                ECores = cpuAdd.ECores,
                CacheL2 = cpuAdd.CacheL2,
                CacheL3 = cpuAdd.CacheL3,
                TechnoProcess = cpuAdd.TechnoProcess,
                CoreName = cpuAdd.CoreName,
                Virtualization = cpuAdd.Virtualization,
                BaseClock = cpuAdd.BaseClock,
                TurboClock = cpuAdd.TurboClock,
                BaseClockECore = cpuAdd.BaseClockECore,
                TurboClockECore = cpuAdd.TurboClockECore,
                FreeMultiplier = cpuAdd.FreeMultiplier,
                Tdp = cpuAdd.Tdp,
                BaseTdp = cpuAdd.BaseTdp,
                MaxTempCpu = cpuAdd.MaxTempCpu,
                MemoryTypeId = cpuAdd.MemoryTypeId,
                MaxValueMemory = cpuAdd.MaxValueMemory,
                MaxChannelMemory = cpuAdd.MaxChannelMemory,
                ClockMemory = cpuAdd.ClockMemory,
                SupportEcc = cpuAdd.SupportEcc,
                PciExpressControllerVersion = cpuAdd.PciExpressControllerVersion,
                CountLinesPciExpress = cpuAdd.CountLinesPciExpress,
                HasGpuCore = cpuAdd.HasGpuCore,
                CpuModelGraphCore = cpuAdd.CpuModelGraphCore,
                CpuMaxClockGraphCore = cpuAdd.CpuMaxClockGraphCore,
                CpuGraphBlocks = cpuAdd.CpuGraphBlocks,
                CpuShadingUnits = cpuAdd.CpuShadingUnits,
            };
            
            return await Task.FromResult(dto);
        }
    }
}