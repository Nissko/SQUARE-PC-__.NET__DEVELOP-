namespace squarePC.Application.Application.Models.Cpus.Create
{
    public class CpuCoreAndArchitectureItem
    {
        public int pCore { get; init; }
        public int eCore { get; init; }
        public string cacheL2 { get; init; }
        public string cacheL3 { get; init; }
        public int technoProcess { get; init; }
        public string coreName { get; init; }
        public bool virtualization { get; init; }
    }
}