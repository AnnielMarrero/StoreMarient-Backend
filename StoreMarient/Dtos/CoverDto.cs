using StoreMarient.Entities;

namespace StoreMarient.Dtos
{
    public class CoverDto : BasicEntityDto
    {
        public required string Model { get; set; }

        public int PhoneTypeId { get; set; }
        public required string PhoneType { get; set; }
    }
}
