using Entities.Model.Common;

namespace Entities.Model.Parameters
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ProductType Type { get; set; }
        public int AvailableInStock { get; set; }
        public int Price { get; set; }
    }
}
