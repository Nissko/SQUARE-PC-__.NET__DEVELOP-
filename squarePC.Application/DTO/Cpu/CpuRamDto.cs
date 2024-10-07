namespace squarePC.Application.DTO.Cpu
{
    public class CpuRamDto
    {
        public Guid MemoryTypeId { get; set; }
        public int? MaxValueMemory { get; set; }
        public int? MaxChannelMemory { get; set; }
        public int? ClockMemory { get; set; }
        public bool? SupportEcc { get; set; }
    }
}