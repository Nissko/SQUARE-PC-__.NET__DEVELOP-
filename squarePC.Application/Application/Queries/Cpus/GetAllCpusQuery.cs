using MediatR;
using CpuEntity = squarePC.Domain.Aggregates.CpuAggregate.CpuEntity;

namespace squarePC.Application.Application.Queries.Cpus
{
    public class GetAllCpusQuery : IRequest<IEnumerable<CpuEntity>>
    { }
}

