using MediatR;
using Microsoft.EntityFrameworkCore;
using squarePC.Application.Application.Interfaces.Cpu;
using squarePC.Application.Common.Interfaces;
using squarePC.Domain.Aggregates.CpuAggregate;

namespace squarePC.Application.Application.Commands.Cpus
{
    /// <summary>
    /// TODO: Переделать исключения
    /// </summary>
    public class ReadCpuFromIdCommandHandler : IRequestHandler<ReadCpuFromIdCommand, CpuEntity>
    {
        private readonly ICpuRepository _cpuRepository;

        public ReadCpuFromIdCommandHandler(ICpuRepository cpuRepository)
        {
            _cpuRepository = cpuRepository?? throw new ArgumentNullException(nameof(cpuRepository));
        }

        public async Task<CpuEntity> Handle(ReadCpuFromIdCommand request, CancellationToken cancellationToken)
        {
            var cpuFind = await _cpuRepository.GetByIdAsync(request.CpuId);

            /*TODO: переписать исключение*/
            if (cpuFind == null) throw new ArgumentNullException("Не найден процессор");

            return cpuFind;
        }
    }
}