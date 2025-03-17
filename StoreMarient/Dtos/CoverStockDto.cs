using StoreMarient.Entities;

namespace StoreMarient.Dtos
{
    public class CoverStockDto : BasicEntityDto
    {
        public int CoverTypeId { get; set; }
        public required string CoverType { get; set; }
        
        public int CoverId { get; set; }
        public required string Model { get; set; }
        public required string PhoneType { get; set; }

        public int Quantity { get; set; }
    }
}
