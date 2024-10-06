namespace squarePC.Application.Application.Models.Cpus.Create
{
    public class CpuRamItem
    {
        public Guid MemoryTypeId { get; init; }
        public int MaxValueMemory { get; init; }
        public int MaxChannelMemory { get; init; }
        public int ClockMemory { get; init; }
        public bool SupportEcc { get; init; }
    }
}