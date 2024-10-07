using MediatR;
using Microsoft.EntityFrameworkCore;
using squarePC.Application.Common.Interfaces;
using squarePC.Domain.Aggregates.CpuAggregate;

namespace squarePC.Application.Application.Queries.Cpus
{
    public class GetAllCpusQueryHandler : IRequestHandler<GetAllCpusQuery, IEnumerable<CpuEntity>>
    {
        private readonly ISquarePcContext _context;

        public GetAllCpusQueryHandler(ISquarePcContext context)
        {
            _context = context?? throw new ArgumentNullException(nameof(context));
        }
        
        /// <summary>
        /// Вывод всех доступных процессоров
        /// </summary>
        public async Task<IEnumerable<CpuEntity>> Handle(GetAllCpusQuery request, CancellationToken cancellationToken)
        {
            var cpus = await _context.Cpus
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
                .ToListAsync() ?? throw new ArgumentNullException("Не удалось найти доступные процессоры");
            
            return cpus;
        }
    }
}

