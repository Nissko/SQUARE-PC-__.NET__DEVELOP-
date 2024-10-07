namespace squarePC.Application.DTO.Cpu
{
    public class CpuDto
    {
        public Guid CpuId { get; set; }
        public decimal? Price { get; set; }
        public int? Count { get; set; }
        public CpuMainInfoDto MainInfo { get; set; }
        public CpuCoreAndArchitectureDto CoreAndArchitecture { get; set; }
        public CpuClocksAndOcDto ClocksAndOc { get; set; }
        public CpuTdpDto Tdp { get; set; }
        public CpuRamDto Ram { get; set; }
        public CpuBusAndControllerDto BusAndController { get; set; }
        public CpuGpuCoreDto GpuCore { get; set; }
    }
}