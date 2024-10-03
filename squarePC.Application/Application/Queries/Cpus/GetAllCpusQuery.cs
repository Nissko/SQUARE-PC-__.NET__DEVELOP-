using MediatR;
using squarePC.Domain.Aggregates.CpuAggregate;

namespace squarePC.Application.Application.Queries.Cpus
{
    public class GetAllCpusQuery : IRequest<IEnumerable<CpuEntity>>
    { }
}

