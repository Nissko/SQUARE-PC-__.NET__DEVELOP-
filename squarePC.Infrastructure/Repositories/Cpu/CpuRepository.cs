using Microsoft.EntityFrameworkCore;
using squarePC.Application.Application.Interfaces.Cpu;
using squarePC.Application.Common.Interfaces;
using squarePC.Application.DTO.Cpu;
using CpuEntity = squarePC.Domain.Aggregates.CpuAggregate.CpuEntity;

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

        private async Task AddAsync(CpuEntity cpu, CancellationToken cancellationToken)
        {
            await _context.Cpus.AddAsync(cpu);
            await _context.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// добавление нового процессора
        /// </summary>
        public async Task CreateCpuAsync(CpuDto cpuDto, CancellationToken cancellationToken)
        {
            var cpu = new CpuEntity(
                cpuPrice: cpuDto.Price,
                cpuCount: cpuDto.Count,
                familyCpuId: cpuDto.FamilyCpuId,
                model: cpuDto.Model,
                socketId: cpuDto.SocketId,
                codeManufacture: cpuDto.CodeManufacture,
                releaseDate: cpuDto.ReleaseDate,
                warranty: cpuDto.Warranty,
                pCores: cpuDto.PCores,
                eCores: cpuDto.ECores,
                cacheL2: cpuDto.CacheL2,
                cacheL3: cpuDto.CacheL3,
                technoProcess: int.Parse(cpuDto.TechnoProcess.Replace(" нм", "")),
                coreName: cpuDto.CoreName,
                virtualization: cpuDto.Virtualization == "Есть",
                baseClock: decimal.Parse(cpuDto.BaseClock.Replace("ГГц", "")),
                turboClock: decimal.Parse(cpuDto.TurboClock.Replace("ГГц", "")),
                baseClockECore: decimal.Parse(cpuDto.BaseClockECore.Replace("ГГц", "")),
                turboClockECore: decimal.Parse(cpuDto.TurboClockECore.Replace("ГГц", "")),
                freeMultiplier: cpuDto.FreeMultiplier == "Да",
                tdp: int.Parse(cpuDto.Tdp),
                baseTdp: int.Parse(cpuDto.BaseTdp),
                maxTempCpu: int.Parse(cpuDto.MaxTempCpu),
                memoryTypeId: cpuDto.MemoryTypeId,
                maxValueMemory: int.Parse(cpuDto.MaxValueMemory),
                maxChannelMemory: int.Parse(cpuDto.MaxChannelMemory),
                clockMemory: int.Parse(cpuDto.ClockMemory),
                supportEcc: cpuDto.SupportEcc == "Да",
                pciExpressControllerVersion: cpuDto.PciExpressControllerVersion,
                countLinesPciExpress: cpuDto.CountLinesPciExpress,
                hasGpuCore: cpuDto.HasGpuCore == "Да",
                cpuModelGraphCore: cpuDto.CpuModelGraphCore,
                cpuMaxClockGraphCore: int.Parse(cpuDto.CpuMaxClockGraphCore.Replace("ГГц", "")),
                cpuGraphBlocks: cpuDto.CpuGraphBlocks,
                cpuShadingUnits: cpuDto.CpuShadingUnits
            );

            await AddAsync(cpu, CancellationToken.None);
        }
        
        /// <summary>
        /// обновление сущности процессора
        /// </summary>
        public async Task UpdateAsync(CpuEntity cpu, CancellationToken cancellationToken)
        {
            _context.Cpus.Update(cpu);
            await _context.SaveChangesAsync(cancellationToken);
        }
        
        
        public async Task UpdateCpuDetailsAsync(CpuDto request, CancellationToken cancellationToken)
        {
            var updateCpu = await GetByIdAsync(request.CpuId);

            /*TODO: переписать исключение*/
            if (updateCpu == null) throw new ArgumentNullException("Процессор не найден");

            /*TODO: дописать и доработать метод по аналогии в CpuEntity, задача от 19.10.2024*/
            updateCpu.UpdateCpuPriceAndCountAsync(updateCpu);

            await UpdateAsync(updateCpu, cancellationToken);
        }

        /// <summary>
        /// Удаление процессора из контекста
        /// </summary>
        public async Task DeleteCpuIdAsync(Guid cpuId, CancellationToken cancellationToken)
        {
            var cpu = await _context.Cpus.Include(img => img.CpuImages)
                .FirstOrDefaultAsync(c => c.Id == cpuId, cancellationToken);

            if (cpu == null)
            {
                throw new ArgumentNullException(nameof(cpu));
            }
            
            _context.Cpus.Remove(cpu);
            
            await _context.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Поиск процессора по ID
        /// </summary>
        public async Task<CpuEntity> GetByIdAsync(Guid cpuId)
        {
            /*TODO: Переписать исключение*/
            return await _context.Cpus.FindAsync(cpuId)
                   ?? throw new ArgumentNullException("Not Found Cpu");
        }
    }
}