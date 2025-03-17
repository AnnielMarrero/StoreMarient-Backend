using StoreMarient.Entities;

namespace StoreMarient.Dtos
{
    public class MicaDto : BasicEntityDto
    {
        public required string Model { get; set; }

        public int Quantity { get; set; }

        public int PhoneTypeId { get; set; }
        public required string PhoneType { get; set; }
    }
}
