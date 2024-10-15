namespace squarePC.Application.DTO.Cpu
{
    public class CpuClocksAndOcDto
    {
        public string BaseClock { get; set; }
        public string TurboClock { get; set; }
        public string BaseClockECore { get; set; }
        public string TurboClockECore { get; set; }
        public string FreeMultiplier { get; set; }
    }
}