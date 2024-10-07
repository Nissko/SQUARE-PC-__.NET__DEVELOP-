namespace squarePC.Application.DTO.Cpu
{
    public class CpuCoreAndArchitectureDto
    {
        public int? PCore { get; set; } 
        public int? ECore { get; set; } 
        public string CacheL2 { get; set; } 
        public string CacheL3 { get; set; }
        public int? TechnoProcess { get; set; }
        public string CoreName { get; set; }
        public bool? Virtualization { get; set; }
    }
}