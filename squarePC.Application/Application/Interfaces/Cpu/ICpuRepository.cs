using squarePC.Application.DTO.Cpu;
using squarePC.Domain.Aggregates.CpuAggregate;

namespace squarePC.Application.Application.Interfaces.Cpu
{
    /// <summary>
    /// TODO: Написать комментарии
    /// </summary>
    public interface ICpuRepository
    {
        /**/
        Task<IEnumerable<CpuEntity>> GetAllAsync();
        /**/
        Task AddAsync(CpuEntity cpu, CancellationToken cancellationToken);
        /**/
        Task CreateCpuAsync(CpuDto cpuDto, CancellationToken cancellationToken);
        /**/
        Task UpdateAsync(CpuEntity cpu, CancellationToken cancellationToken);
        /**/
        Task UpdateCpuDetailsAsync(CpuDto updateRequest, CancellationToken cancellationToken);
        /**/
        Task DeleteCpuIdAsync(Guid cpuId, CancellationToken cancellationToken);
        /**/
        Task<CpuEntity> GetByIdAsync(Guid cpuId);
    }
}