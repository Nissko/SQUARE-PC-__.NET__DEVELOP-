namespace squarePC.Application.DTO.Cpu
{
    public class CpuGpuCoreDto
    {
        public bool? HasGpuCore { get; set; }
        public string CpuModelGraphCore { get; set; }
        public int? CpuMaxClockGraphCore { get; set; }
        public int? CpuGraphBlocks { get; set; }
        public int? CpuShadingUnits { get; set; }
    }
}