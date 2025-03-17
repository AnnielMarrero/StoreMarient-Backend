using StoreMarient.Entities;

namespace StoreMarient.Dtos
{
    public class PhoneDto : BasicEntityDto
    {
        public required string Model { get; set; }

        public int Quantity { get; set; }

        public int PieceId { get; set; }
        public required string Piece { get; set; }
    }
}
