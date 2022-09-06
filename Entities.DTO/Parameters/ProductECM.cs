using System;

namespace Entities.DTO.Parameters
{
    public class ProductECM
    {
        public string Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int ProductType { get; set; }
        public int ProductAvailableInStock { get; set; }
        public int ProductPrice { get; set; }
    }
}
