using squarePC.Application.DTO.Cpu;
using squarePC.Domain.Aggregates.CpuAggregate;

namespace squarePC.Application.Application.Interfaces.Cpu
{
    public interface ICpuRepository
    {
        Task<IEnumerable<CpuEntity>> GetAllAsync();
        Task AddAsync(CpuEntity cpu, CancellationToken cancellationToken);
        Task<CpuEntity> UpdateAsync(CpuEntity cpu, CancellationToken cancellationToken);
        Task UpdateCpuDetailsAsync(CpuDto updateRequest, CancellationToken cancellationToken);
        Task DeleteAsync(Guid cpuId, CancellationToken cancellationToken);
        Task<CpuEntity> GetByIdAsync(Guid cpuId);
    }
}