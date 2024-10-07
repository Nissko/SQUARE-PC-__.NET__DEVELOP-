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
            return await _context.Cpus
                .Include(t => t.CpuMainInfo)
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
                .ToListAsync();
        }

        public async Task AddAsync(CpuEntity cpu, CancellationToken cancellationToken)
        {
            await _context.Cpus.AddAsync(cpu);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<CpuEntity> UpdateAsync(CpuEntity cpu, CancellationToken cancellationToken)
        {
            _context.Cpus.Update(cpu);
            await _context.SaveChangesAsync(cancellationToken);
            return cpu;
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
                updateRequest.CoreAndArchitecture.TechnoProcess,
                updateRequest.CoreAndArchitecture.CoreName,
                updateRequest.CoreAndArchitecture.Virtualization,
                updateRequest.ClocksAndOc.BaseClock,
                updateRequest.ClocksAndOc.TurboClock,
                updateRequest.ClocksAndOc.BaseClockECore,
                updateRequest.ClocksAndOc.TurboClockECore,
                updateRequest.ClocksAndOc.FreeMultiplier,
                updateRequest.Tdp.Tdp,
                updateRequest.Tdp.BaseTdp,
                updateRequest.Tdp.MaxTempCpu,
                updateRequest.Ram.MemoryTypeId,
                updateRequest.Ram.MaxValueMemory,
                updateRequest.Ram.MaxChannelMemory,
                updateRequest.Ram.ClockMemory,
                updateRequest.Ram.SupportEcc,
                updateRequest.BusAndController.PciExpressControllerVersion,
                updateRequest.BusAndController.CountLinesPciExpress,
                updateRequest.GpuCore.HasGpuCore,
                updateRequest.GpuCore.CpuModelGraphCore,
                updateRequest.GpuCore.CpuMaxClockGraphCore,
                updateRequest.GpuCore.CpuGraphBlocks,
                updateRequest.GpuCore.CpuShadingUnits
            );

            await UpdateAsync(existingCpu, cancellationToken);
        }


        public async Task DeleteAsync(Guid cpuId, CancellationToken cancellationToken)
        {
            var cpu = await _context.Cpus.FindAsync(cpuId);
            if (cpu != null)
            {
                _context.Cpus.Remove(cpu);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task<CpuEntity> GetByIdAsync(Guid cpuId)
        {
            return await _context.Cpus
                .Include(t => t.CpuMainInfo)
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
                .FirstOrDefaultAsync(t => t.Id == cpuId);
        }
    }
}