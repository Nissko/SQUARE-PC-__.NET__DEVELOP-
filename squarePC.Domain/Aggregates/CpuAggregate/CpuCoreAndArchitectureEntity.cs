using squarePC.Domain.Common;

namespace squarePC.Domain.Aggregates.CpuAggregate
{
    /// <summary>
    /// Ядро и архитектура процессора
    /// </summary>
    public class CpuCoreAndArchitectureEntity : Entity
    {
        public CpuCoreAndArchitectureEntity(int pCores, int eCores, string cacheL2, string cacheL3,
            int technoProcess, string coreName, bool virtualization)
        {
            _pCores = pCores;
            _eCores = eCores;
            _allCores = _pCores + _eCores;
            _cacheL2 = cacheL2;
            _cacheL3 = cacheL3;
            _technoProcess = technoProcess;
            _coreName = coreName;
            _virtualization = virtualization;
            _allThreads = CalculationAllTheadsFunction(_pCores, _eCores, _virtualization);
        }
        
        /// <summary>
        /// Общее количество ядер
        /// </summary>
        private int _allCores;
        public int CpuAllCores => _allCores;

        /// <summary>
        /// Количество производительных ядер
        /// </summary>
        private int _pCores;
        public int CpuPCores => _pCores;

        /// <summary>
        /// Количество энергоэффективных ядер
        /// </summary>
        private int _eCores;
        public int CpuECores => _eCores;

        /// <summary>
        /// Общее число потоков
        /// </summary>
        private int _allThreads;
        public int CpuAllThreads => _allThreads;

        /// <summary>
        /// Кэш L2
        /// </summary>
        private string _cacheL2;
        public string CpuCacheL2 => _cacheL2;

        /// <summary>
        /// Кэш L3
        /// </summary>
        private string _cacheL3;
        public string CpuCacheL3 => _cacheL3;

        /// <summary>
        /// Техпроцесс
        /// </summary>
        private int _technoProcess;
        public string CpuTechnoProcess => _technoProcess + " нм";

        /// <summary>
        /// Ядро
        /// </summary>
        private string _coreName;
        public string CpuCoreName => _coreName;

        /// <summary>
        /// Технология виртуализации
        /// </summary>
        private bool _virtualization;
        public string CpuVirtualisation => _virtualization ? "Есть" : "Нет";

        /// <summary>
        /// Расчет потоков процессора
        /// </summary>
        private int CalculationAllTheadsFunction(int pCores, int eCores, bool virtualization)
        {
            if (virtualization)
                pCores *= 2;

            var totalThreads = pCores + eCores;

            return totalThreads;
        }
    }
}