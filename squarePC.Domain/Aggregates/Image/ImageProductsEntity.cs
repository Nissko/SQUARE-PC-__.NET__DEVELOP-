using squarePC.Domain.Aggregates.CpuAggregate;
using squarePC.Domain.Common;

namespace squarePC.Domain.Aggregates.Image
{
    /// <summary>
    /// Сущность хранилища изображений для товаров
    /// </summary>
    public class ImageProductsEntity : Entity
    {
        public ImageProductsEntity(string name, byte[] image, int displayOrder)
        {
            _name = name;
            _image = image;
            _displayOrder = displayOrder;
        }
        
        /// <summary>
        /// Название изображения
        /// </summary>
        private string _name;
        public string Name => _name;

        /// <summary>
        /// Порядок отображения
        /// </summary>
        private int _displayOrder;
        public int DisplayOrder => _displayOrder;
        
        /// <summary>
        /// Изображение
        /// </summary>
        private byte[] _image;
        public byte[] Image => _image;

        public virtual IReadOnlyCollection<CpuImageEntity> CpuImages { get; private set; }
    }
}