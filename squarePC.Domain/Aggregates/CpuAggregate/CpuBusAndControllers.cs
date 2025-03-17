namespace squarePC.Domain.Aggregates.CpuAggregate
{
    /// <summary>
    /// Шина и контроллер процессора
    /// </summary>
    public sealed partial class CpuEntity
    {
        /// <summary>
        /// Встроенный контроллер PCI Express
        /// </summary>
        private string _pciExpressControllerVersion;
        public string PciExpressControllerVersion => _pciExpressControllerVersion;

        /// <summary>
        /// Число линий PCI Express
        /// </summary>
        private int _countLinesPciExpress;
        public int CountLinesPciExpress => _countLinesPciExpress;

        public async Task UpdateBusAndController(string pciExpressControllerVersion,
            int countLinesPciExpress)
        {
            _pciExpressControllerVersion = pciExpressControllerVersion;
            _countLinesPciExpress = countLinesPciExpress;

            await Task.CompletedTask;
        }
    }
}