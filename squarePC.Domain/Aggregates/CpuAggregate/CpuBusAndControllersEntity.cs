using squarePC.Domain.Common;

namespace squarePC.Domain.Aggregates.CpuAggregate
{
    /// <summary>
    /// Шина и контроллер процессора
    /// </summary>
    public class CpuBusAndControllersEntity : Entity
    {
        public CpuBusAndControllersEntity(string pciExpressControllerVersion, int countLinesPciExpress, Guid cpuId)
        {
            _pciExpressControllerVersion = pciExpressControllerVersion;
            _countLinesPciExpress = countLinesPciExpress;
            CpuId = cpuId;
        }

        /// <summary>
        /// Внешний ключ процессора
        /// </summary>
        public Guid CpuId { get; private set; }

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
    }
}