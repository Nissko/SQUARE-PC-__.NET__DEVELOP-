using squarePC.Application.DTO.Cpu;
using CpuEntity = squarePC.Domain.Aggregates.CpuAggregate.CpuEntity;

namespace squarePC.Application.Application.Interfaces.Cpu
{
    /// <summary>
    /// TODO: Написать комментарии
    /// </summary>
    public interface ICpuRepository
    {
        /// <summary>
        /// Получение всех процессоров
        /// </summary>
        Task<IEnumerable<CpuEntity>> GetAllAsync();
        
        /// <summary>
        /// Добавление нового процессора
        /// </summary>
        Task CreateCpuAsync(CpuDto cpuDto, CancellationToken cancellationToken);
        
        /// <summary>
        /// Сохранение изменений контекста после изменения
        /// </summary>
        Task UpdateAsync(CpuEntity cpu, CancellationToken cancellationToken);
        
        /// <summary>
        /// Изменение существующего процессора
        /// </summary>
        Task UpdateCpuDetailsAsync(CpuDto updateRequest, CancellationToken cancellationToken);
        
        /// <summary>
        /// Удаление из базы процессора
        /// </summary>
        Task DeleteCpuIdAsync(Guid cpuId, CancellationToken cancellationToken);
        
        /// <summary>
        /// Вывод процессора по Id
        /// </summary>
        Task<CpuEntity> GetByIdAsync(Guid cpuId);
    }
}