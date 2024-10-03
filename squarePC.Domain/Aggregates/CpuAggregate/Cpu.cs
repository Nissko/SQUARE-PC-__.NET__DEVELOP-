using squarePC.Domain.Common;

namespace squarePC.Domain.Aggregates.ConfigurationAggregate
{
    public class Cpu : Entity
    {

        public Cpu(Guid familyCpu, string model, Guid socket, string codeManufacture, DateTime releaseDate,
            string warranty, bool virtualisation, int pCores, int? eCores, string cacheL2, string cacheL3,
            int technoProcess, string coreName, decimal baseClock, decimal turboClock, decimal? baseClockECore,
            decimal? turboClockECore, bool freeMultiplier)
        {
            #region Общие параметры

            _familyCpu = familyCpu;
            _model = model;
            _socket = socket;
            _codeManufacture = codeManufacture;
            _releaseDate = releaseDate;
            _warranty = warranty;
            _virtualisation = virtualisation;
            
            #endregion

            #region Ядро и архитектура

            _pCores = pCores;
            _eCores = eCores ?? 0;
            _allCores = _pCores + _eCores ?? 0;
            _allThreads = CalculationAllTheadsFunction(_pCores, _eCores ?? 0, _virtualisation);
            _cacheL2 = cacheL2;
            _cacheL3 = cacheL3;
            _technoProcess = technoProcess;
            _coreName = coreName;

            #endregion

            #region Частота и возможность разгона

            _baseClock = baseClock;
            _turboClock = turboClock;
            _baseClockECore = baseClockECore ?? 0;
            _turboClockECore = turboClockECore ?? 0;
            _freeMultiplier = freeMultiplier;

            #endregion

            
        }

        #region Общие параметры

        /// <summary>
        /// Название процессора
        /// </summary>
        private string _name;
        public string CpuName => CpuNameFunction(CpuFamily, _model);

        /// <summary>
        /// Семейство процессора
        /// </summary>
        private Guid _familyCpu;

        public string CpuFamily => CpuFamilyEnum.From(_familyCpu);

        /// <summary>
        /// Модель
        /// </summary>
        private string _model;

        public string CpuModel => _model;

        /// <summary>
        /// Сокет
        /// </summary>
        private Guid _socket;

        public string CpuSocket => CpuSocketEnum.From(_socket);

        /// <summary>
        /// Код производителя
        /// </summary>
        private string _codeManufacture;

        private string CpuManufacture => _codeManufacture;

        /// <summary>
        /// Дата выхода
        /// </summary>
        private DateTime _releaseDate;

        public DateTime CpuReleaseDate => _releaseDate;

        /// <summary>
        /// Гарантия
        /// </summary>
        private string _warranty;

        public string CpuWarranty => _warranty;

        /// <summary>
        /// Технология виртуализации
        /// </summary>
        private bool _virtualisation;

        public string CpuVirtualisation => _virtualisation ? "Есть" : "Нет";

        #endregion

        #region Ядро и архитектура

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
        private int? _eCores;

        public int CpuECores => _eCores ?? 0;

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

        #endregion

        #region Частота и возможность разгона

        /// <summary>
        /// Базовая частота процессора
        /// </summary>
        private decimal _baseClock;

        public string CpuBaseClock => _baseClock + "ГГц";

        /// <summary>
        /// Макзимальная частота
        /// </summary>
        private decimal _turboClock;
        public string CpuTurboClock => _turboClock + "ГГц";

        /// <summary>
        /// Базовая частота энергоэффективных ядер
        /// </summary>
        private decimal? _baseClockECore;

        public string CpuBaseClockECore => _baseClockECore + "ГГц";

        /// <summary>
        /// Турбо частота энергоэффективных ядер
        /// </summary>
        private decimal? _turboClockECore;

        public string CpuTurboClockECore => _turboClockECore + "ГГц";

        /// <summary>
        /// Свободный множитель
        /// </summary>
        private bool _freeMultiplier;

        public string CpuFreeMultiplier => _freeMultiplier ? "Да" : "Нет";

        #endregion

        #region Параметры ОЗУ

        /// <summary>
        /// Тип поддерживаемой памяти
        /// TODO: Сделать справочник
        /// </summary>
        private string _memoryType;

        /// <summary>
        /// Максимально поддерживаемый объем памяти
        /// </summary>
        private int _maxValueMemory;

        /// <summary>
        /// Количество каналов
        /// </summary>
        private int _maxChannelMemory;

        /// <summary>
        /// Частота оперативной памяти
        /// </summary>
        private int _clockMemory;

        /// <summary>
        /// Поддержка режима ECC
        /// </summary>
        private bool _supportECC;

        #endregion

        #region Тепловые характеристики

        /// <summary>
        /// Тепловыделение
        /// </summary>
        private int _TDP;

        /// <summary>
        /// Базовое тепловыделение
        /// </summary>
        private int _baseTDP;

        /// <summary>
        /// Максимальная температура процессора
        /// </summary>
        private int _maxTempCPU;

        #endregion

        #region Графическое ядро



        #endregion

        #region Шина и контроллеры

        /// <summary>
        /// Встроенный контроллер PCI Express
        /// </summary>
        private string _pciExpressControllerVersion;

        /// <summary>
        /// Число линий PCI Express
        /// </summary>
        private int _countLinesPciExpress;

        #endregion

        #region Функции Сеттеры

        /// <summary>
        /// Формирование названия процессора
        /// </summary>
        /// <param name="familyCpu"></param>
        /// <param name="modelCpu"></param>
        private string CpuNameFunction(string familyCpu, string modelCpu)
        {
            if (familyCpu.Length == 0 || modelCpu.Length == 0)
            {
                /*TODO: переписать исключение*/
                throw new Exception("Exception");
            }

            _name = $"Процессор {familyCpu} {modelCpu}";

            return _name;
        }
        
        /// <summary>
        /// Расчет потоков процессора
        /// </summary>
        /// <param name="pCores"></param>
        /// <param name="eCores"></param>
        /// <param name="virtualisation"></param>
        private int CalculationAllTheadsFunction(int pCores, int eCores, bool virtualisation)
        {
            var totalThreads = 0;

            if (virtualisation)
            {
                pCores *= 2;
            }

            totalThreads = pCores + eCores;

            return totalThreads;
        }

        #endregion
        
    }
}

