using squarePC.Domain.Enums.CpuEnums;

namespace squarePC.Domain.Aggregates.CpuAggregate
{
    /// <summary>
    /// Общие параметры процессора
    /// </summary>
    public sealed partial class CpuEntity
    {
        /// <summary>
        /// Название процессора
        /// </summary>
        private string _name;
        public string CpuName => _name;

        /// <summary>
        /// Семейство процессора
        /// </summary>
        private Guid _familyCpuId;
        public CpuFamilyEnum CpuFamily { get; private set; }

        /// <summary>
        /// Модель
        /// </summary>
        private string _model;
        public string CpuModel => _model;

        /// <summary>
        /// Сокет
        /// </summary>
        private Guid _socketId;
        public CpuSocketEnum CpuSocket { get; private set; }

        /// <summary>
        /// Код производителя
        /// </summary>
        private string _codeManufacture;
        public string CpuManufacture => _codeManufacture;

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
        /// Формирование названия процессора
        /// </summary>
        private string CpuNameFunction(Guid familyCpuId, string modelCpu)
        {
            var familyCpu = CpuFamilyEnum.From(familyCpuId);

            if (familyCpu.Length == 0 || modelCpu.Length == 0)
            {
                /*TODO: переписать исключение*/
                throw new Exception("Exception");
            }

            _name = $"Процессор {familyCpu} {modelCpu}";

            return _name;
        }
        
        #region Update

        /// <summary>
        /// Изменение всех основных данных процессора
        /// </summary>
        public async void UpdateCpuMainInfo(CpuEntity cpuMainInfo)
        {
            await UpdateFamilyAndModel(cpuMainInfo._familyCpuId, cpuMainInfo._model);
            await UpdateSocket(cpuMainInfo._socketId);
            await UpdateCodeManufacture(cpuMainInfo._codeManufacture);
            await UpdateReleaseDate(cpuMainInfo._releaseDate);
            await UpdateWarranty(cpuMainInfo._warranty);
        }
        
        /// <summary>
        /// Изменение семейства и модели
        /// </summary>
        private async Task UpdateFamilyAndModel(Guid? familyCpuId, string modelCpu)
        {
            _familyCpuId = familyCpuId ?? _familyCpuId;
            _model = !string.IsNullOrEmpty(modelCpu) ? modelCpu : _warranty;
            
            _name = CpuNameFunction(_familyCpuId, _model);
        }

        /// <summary>
        /// Изменение сокета
        /// </summary>
        private async Task UpdateSocket(Guid? socketId)
        {
            _socketId = socketId ?? _socketId;
        }

        /// <summary>
        /// Изменение кода производителя
        /// </summary>
        private async Task UpdateCodeManufacture(string codeManufacture)
        {
            _codeManufacture = !string.IsNullOrEmpty(codeManufacture) ? codeManufacture : _warranty;
        }

        /// <summary>
        /// Изменение даты выхода
        /// </summary>
        private async Task UpdateReleaseDate(DateTime? dateTime)
        {
            _releaseDate = dateTime?? _releaseDate;
        }

        /// <summary>
        /// Изменение гарантии
        /// </summary>
        private async Task UpdateWarranty(string warranty)
        {
            _warranty = !string.IsNullOrEmpty(warranty) ? warranty : _warranty;
        }

        #endregion
        
    }
}