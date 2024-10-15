namespace squarePC.Application.DTO.Cpu
{
    public class CpuCoreAndArchitectureDto
    {
        public int? PCore { get; set; } 
        public int? ECore { get; set; } 
        public string CacheL2 { get; set; } 
        public string CacheL3 { get; set; }
        public string TechnoProcess { get; set; }
        public string CoreName { get; set; }
        public string Virtualization { get; set; }
    }
}