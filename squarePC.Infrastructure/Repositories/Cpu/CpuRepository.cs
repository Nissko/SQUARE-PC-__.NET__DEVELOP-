using Microsoft.EntityFrameworkCore;
using squarePC.Application.Application.Interfaces.Cpu;
using squarePC.Application.Common.Interfaces;
using squarePC.Application.DTO.Cpu;
using squarePC.Domain.Aggregates.CpuAggregate;

namespace squarePC.Infrastructure.Repositories.Cpu
{
    public class CpuRepository : ICpuRepository
    {
        private readonly ISquarePcContext _context;

        public CpuRepository(ISquarePcContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        
        public async Task<IEnumerable<CpuEntity>> GetAllAsync()
        {
            return await _context.Cpus.ToListAsync();
        }

        public async Task AddAsync(CpuEntity cpu, CancellationToken cancellationToken)
        {
            await _context.Cpus.AddAsync(cpu);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task CreateCpuAsync(CpuDto cpuDto, CancellationToken cancellationToken)
        {
            var cpu = new CpuEntity(
                cpuPrice: cpuDto.Price.Value,
                cpuCount: cpuDto.Count.Value,
                cpuMainInfo: new CpuMainInfoEntity(
                    familyCpuId: cpuDto.MainInfo.FamilyCpuId,
                    model: cpuDto.MainInfo.Model,
                    socketId: cpuDto.MainInfo.SocketId,
                    codeManufacture: cpuDto.MainInfo.CodeManufacture,
                    releaseDate: cpuDto.MainInfo.ReleaseDate.Value,
                    warranty: cpuDto.MainInfo.Warranty
                ),
                cpuCoreAndArchitecture: new CpuCoreAndArchitectureEntity(
                    pCores: cpuDto.CoreAndArchitecture.PCore.Value,
                    eCores: cpuDto.CoreAndArchitecture.ECore.Value,
                    cacheL2: cpuDto.CoreAndArchitecture.CacheL2,
                    cacheL3: cpuDto.CoreAndArchitecture.CacheL3,
                    technoProcess: int.Parse(cpuDto.CoreAndArchitecture.TechnoProcess),
                    coreName: cpuDto.CoreAndArchitecture.CoreName,
                    virtualization: bool.Parse(cpuDto.CoreAndArchitecture.Virtualization)
                ),
                cpuClocksAndOc: new CpuClocksAndOcEntity(
                    baseClock: decimal.Parse(cpuDto.ClocksAndOc.BaseClock),
                    turboClock: decimal.Parse(cpuDto.ClocksAndOc.TurboClock),
                    baseClockECore: decimal.Parse(cpuDto.ClocksAndOc.BaseClockECore),
                    turboClockECore: decimal.Parse(cpuDto.ClocksAndOc.TurboClockECore),
                    freeMultiplier: bool.Parse(cpuDto.ClocksAndOc.FreeMultiplier)
                ),
                cpuTdp: new CpuTdpInfoEntity(
                    tdp: int.Parse(cpuDto.Tdp.Tdp),
                    baseTdp: int.Parse(cpuDto.Tdp.BaseTdp),
                    maxTempCpu: int.Parse(cpuDto.Tdp.MaxTempCpu)
                ),
                cpuRam: new CpuRamInfoEntity(
                    memoryTypeId: cpuDto.Ram.MemoryTypeId,
                    maxValueMemory: int.Parse(cpuDto.Ram.MaxValueMemory),
                    maxChannelMemory: int.Parse(cpuDto.Ram.MaxChannelMemory),
                    clockMemory: int.Parse(cpuDto.Ram.ClockMemory),
                    supportEcc: bool.Parse(cpuDto.Ram.SupportEcc)
                ),
                cpuBusAndController: new CpuBusAndControllersEntity(
                    pciExpressControllerVersion: cpuDto.BusAndController.PciExpressControllerVersion,
                    countLinesPciExpress: cpuDto.BusAndController.CountLinesPciExpress
                ),
                cpuGpuCore: new CpuGpuCoreInfoEntity(
                    hasGpuCore: bool.Parse(cpuDto.GpuCore.HasGpuCore),
                    cpuModelGraphCore: cpuDto.GpuCore.CpuModelGraphCore,
                    cpuMaxClockGraphCore: int.Parse(cpuDto.GpuCore.CpuMaxClockGraphCore),
                    cpuGraphBlocks: int.Parse(cpuDto.GpuCore.CpuGraphBlocks),
                    cpuShadingUnits: int.Parse(cpuDto.GpuCore.CpuShadingUnits)
                ));

            await AddAsync(cpu, CancellationToken.None);
        }
        
        public async Task UpdateAsync(CpuEntity cpu, CancellationToken cancellationToken)
        {
            _context.Cpus.Update(cpu);
            await _context.SaveChangesAsync(cancellationToken);
        }
        
        public async Task UpdateCpuDetailsAsync(CpuDto updateRequest, CancellationToken cancellationToken)
        {
            var existingCpu = await GetByIdAsync(updateRequest.CpuId);

            /*TODO: переписать исключение*/
            if (existingCpu == null) throw new ArgumentNullException("Процессор не найден");

            await existingCpu.UpdateCpu(
                updateRequest.CpuId,
                updateRequest.Price,
                updateRequest.Count,
                updateRequest.MainInfo.FamilyCpuId,
                updateRequest.MainInfo.Model,
                updateRequest.MainInfo.SocketId,
                updateRequest.MainInfo.CodeManufacture,
                updateRequest.MainInfo.ReleaseDate,
                updateRequest.MainInfo.Warranty,
                updateRequest.CoreAndArchitecture.PCore,
                updateRequest.CoreAndArchitecture.ECore,
                updateRequest.CoreAndArchitecture.CacheL2,
                updateRequest.CoreAndArchitecture.CacheL3,
                int.Parse(updateRequest.CoreAndArchitecture.TechnoProcess),
                updateRequest.CoreAndArchitecture.CoreName,
                bool.Parse(updateRequest.CoreAndArchitecture.Virtualization),
                decimal.Parse(updateRequest.ClocksAndOc.BaseClock),
                decimal.Parse(updateRequest.ClocksAndOc.TurboClock),
                decimal.Parse(updateRequest.ClocksAndOc.BaseClockECore),
                decimal.Parse(updateRequest.ClocksAndOc.TurboClockECore),
                bool.Parse(updateRequest.ClocksAndOc.FreeMultiplier),
                int.Parse(updateRequest.Tdp.Tdp),
                int.Parse(updateRequest.Tdp.BaseTdp),
                int.Parse(updateRequest.Tdp.MaxTempCpu),
                updateRequest.Ram.MemoryTypeId,
                int.Parse(updateRequest.Ram.MaxValueMemory),
                int.Parse(updateRequest.Ram.MaxChannelMemory),
                int.Parse(updateRequest.Ram.ClockMemory),
                bool.Parse(updateRequest.Ram.SupportEcc),
                updateRequest.BusAndController.PciExpressControllerVersion,
                updateRequest.BusAndController.CountLinesPciExpress,
                bool.Parse(updateRequest.GpuCore.HasGpuCore),
                updateRequest.GpuCore.CpuModelGraphCore,
                int.Parse(updateRequest.GpuCore.CpuMaxClockGraphCore),
                int.Parse(updateRequest.GpuCore.CpuGraphBlocks),
                int.Parse(updateRequest.GpuCore.CpuShadingUnits)
            );

            await UpdateAsync(existingCpu, cancellationToken);
        }

        public async Task DeleteCpuIdAsync(Guid cpuId, CancellationToken cancellationToken)
        {
            var cpu = await _context.Cpus
                .Include(c => c.CpuMainInfo)
                .Include(c => c.CpuCoreAndArchitecture)
                .Include(c => c.CpuClocksAndOc)
                .Include(c => c.CpuTdp)
                .Include(c => c.CpuRam)
                .Include(c => c.CpuBusAndController)
                .Include(c => c.CpuGpuCore)
                .FirstOrDefaultAsync(c => c.Id == cpuId, cancellationToken);
            
            _context.Cpus.Remove(cpu);
            
            _context.CpuMainInfos.Remove(cpu.CpuMainInfo);
            _context.CpuCoreAndArchitectures.Remove(cpu.CpuCoreAndArchitecture);
            _context.CpuClocksAndOcs.Remove(cpu.CpuClocksAndOc);
            _context.CpuTdpInfos.Remove(cpu.CpuTdp);
            _context.CpuRamInfos.Remove(cpu.CpuRam);
            _context.CpuBusAndControllers.Remove(cpu.CpuBusAndController);
            _context.CpuGpuCoreInfos.Remove(cpu.CpuGpuCore);
            
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<CpuEntity> GetByIdAsync(Guid cpuId)
        {
            /*TODO: Переписать исключение*/
            return await _context.Cpus.FindAsync(cpuId) ?? throw new ArgumentNullException("Not Found Cpu");
        }
    }
}