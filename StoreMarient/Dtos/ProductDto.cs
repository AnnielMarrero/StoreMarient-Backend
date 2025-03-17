using StoreMarient.Entities;

namespace StoreMarient.Dtos
{
    public class ProductDto : BasicEntityDto
    {
        public required string Name { get; set; }

        public int Quantity { get; set; }

        public int CategoryId { get; set; }
        public required string Category { get; set; }
    }
}
