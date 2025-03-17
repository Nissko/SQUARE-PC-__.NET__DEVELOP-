using MediatR;
using squarePC.Application.Application.Interfaces.Cpu;
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
            var cpuDto = await ConstructCpuDto(request);

            await _repository.CreateCpuAsync(cpuDto, cancellationToken);
            
            return Unit.Value;
        }

        private static async Task<CpuDto> ConstructCpuDto(CreateNewCpuCommand request)
        {
            var cpuAdd = request.CreateCpu;
            var dto = new CpuDto
            {
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