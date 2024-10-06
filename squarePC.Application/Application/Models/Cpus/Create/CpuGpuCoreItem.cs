namespace squarePC.Application.Application.Models.Cpus.Create
{
    public class CpuGpuCoreItem
    {
        public bool hasGpuCore { get; init; }
        public string cpuModelGraphCore { get; init; }
        public int cpuMaxClockGraphCore { get; init; }
        public int cpuGraphBlocks { get; init; }
        public int cpuShadingUnits { get; init; }
    }
}