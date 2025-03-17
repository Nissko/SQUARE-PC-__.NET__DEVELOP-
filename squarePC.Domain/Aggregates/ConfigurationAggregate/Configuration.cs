using squarePC.Domain.Common;

namespace squarePC.Domain.Aggregates.ConfigurationAggregate
{
    /// <summary>
    /// Компьютерная конфигурация
    /// </summary>
    public class Configuration : Entity
    {
        /// <summary>
        /// Название
        /// </summary>
        private string _name;
        
        /// <summary>
        /// Описание
        /// </summary>
        private string _description;
        
        /// <summary>
        /// Модельный ряд
        /// </summary>
        private string _modelName;
        
        /// <summary>
        /// Цена
        /// </summary>
        private decimal _price;

        /// <summary>
        /// Процессор
        /// </summary>
        private string _cpu;
        
        /// <summary>
        /// Материнская плата
        /// </summary>
        private string _motherboard;
        
        /// <summary>
        /// Оперативная память
        /// </summary>
        private string _ram;
        private int _countRams;
        
        /// <summary>
        /// Видеокарта
        /// </summary>
        private string _gpu;
        
        /// <summary>
        /// Блок питания
        /// </summary>
        private string _psu;
        
        /// <summary>
        /// Система охлаждения
        /// </summary>
        private string _cooling;
        
        /// <summary>
        /// Корпус
        /// </summary>
        private string _case;
        
        /// <summary>
        /// Жесткий диск
        /// </summary>
        private string _disk;
        private int _countDisks;
        
        /// <summary>
        /// Твердотельный накопитель
        /// </summary>
        private string _ssd;
        private int _countSsds;
    }
}
