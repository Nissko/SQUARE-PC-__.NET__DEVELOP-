namespace squarePC.Application.DTO.Cpu
{
    public class CpuClocksAndOcDto
    {
        public decimal? BaseClock { get; set; }
        public decimal? TurboClock { get; set; }
        public decimal? BaseClockECore { get; set; }
        public decimal? TurboClockECore { get; set; }
        public bool? FreeMultiplier { get; set; }
    }
}