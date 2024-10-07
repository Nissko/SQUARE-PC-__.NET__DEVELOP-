using MediatR;
using squarePC.Application.Application.Interfaces.Cpu;
using squarePC.Domain.Aggregates.CpuAggregate;

namespace squarePC.Application.Application.Queries.Cpus
{
    public class GetAllCpusQueryHandler : IRequestHandler<GetAllCpusQuery, IEnumerable<CpuEntity>>
    {
        private readonly ICpuRepository _cpuRepository;

        public GetAllCpusQueryHandler(ICpuRepository cpuRepository)
        {
            _cpuRepository = cpuRepository?? throw new ArgumentNullException(nameof(cpuRepository));
        }
        
        /// <summary>
        /// Вывод всех доступных процессоров
        /// </summary>
        public async Task<IEnumerable<CpuEntity>> Handle(GetAllCpusQuery request, CancellationToken cancellationToken)
        {
            var cpus = await _cpuRepository.GetAllAsync();
            
            return cpus;
        }
    }
}

