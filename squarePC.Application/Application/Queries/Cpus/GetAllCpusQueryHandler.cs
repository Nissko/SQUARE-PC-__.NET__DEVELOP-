using MediatR;
using squarePC.Application.Application.Interfaces.Cpu;
using squarePC.Application.Common.Interfaces;
using squarePC.Application.DTO.Cpu;
using squarePC.Domain.Aggregates.CpuAggregate;

namespace squarePC.Application.Application.Queries.Cpus
{
    public class GetAllCpusQueryHandler : IRequestHandler<GetAllCpusQuery, IEnumerable<CpuEntity>>
    {
        private readonly ICpuRepository _cpuRepository;
        private readonly ICustomMapper _mapper;

        public GetAllCpusQueryHandler(ICpuRepository cpuRepository, ICustomMapper mapper)
        {
            _cpuRepository = cpuRepository?? throw new ArgumentNullException(nameof(cpuRepository));
            _mapper = mapper?? throw new ArgumentNullException(nameof(mapper));
        }
        
        /// <summary>
        /// Вывод всех доступных процессоров
        /// </summary>
        public async Task<IEnumerable<CpuEntity>> Handle(GetAllCpusQuery request, CancellationToken cancellationToken)
        {
            var cpus = await _cpuRepository.GetAllAsync();
            
            /*TODO: Сделать вывод через AutoMapper*/
            return cpus;
        }
    }
}

