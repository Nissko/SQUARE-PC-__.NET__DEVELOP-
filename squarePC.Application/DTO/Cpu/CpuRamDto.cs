namespace squarePC.Application.DTO.Cpu
{
    public class CpuRamDto
    {
        public Guid MemoryTypeId { get; set; }
        public string MaxValueMemory { get; set; }
        public string MaxChannelMemory { get; set; }
        public string ClockMemory { get; set; }
        public string SupportEcc { get; set; }
    }
}