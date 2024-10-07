using MediatR;
using Microsoft.EntityFrameworkCore;
using squarePC.Application.Common.Interfaces;
using squarePC.Domain.Aggregates.CpuAggregate;

namespace squarePC.Application.Application.Commands.Cpus
{
    /// <summary>
    /// TODO: Переделать исключения
    /// </summary>
    public class ReadCpuFromIdCommandHandler : IRequestHandler<ReadCpuFromIdCommand, CpuEntity>
    {
        private readonly ISquarePcContext _context;

        public ReadCpuFromIdCommandHandler(ISquarePcContext context)
        {
            _context = context?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<CpuEntity> Handle(ReadCpuFromIdCommand request, CancellationToken cancellationToken)
        {
            var cpuFind = await _context.Cpus
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
                              .FirstOrDefaultAsync(cpu => cpu.Id == request.CpuId)
                          ?? throw new ArgumentNullException("Не нашелся процессор");

            return cpuFind;
        }
    }
}