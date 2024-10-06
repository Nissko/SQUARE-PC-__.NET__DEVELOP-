namespace squarePC.Application.Application.Models.Cpus.Create
{
    public class CpuClocksAndOcItem
    {
        public decimal baseClock { get; init; }
        public decimal turboClock { get; init; }
        public decimal baseClockECore { get; init; }
        public decimal turboClockECore { get; init; }
        public bool freeMultiplier { get; init; }
    }
}