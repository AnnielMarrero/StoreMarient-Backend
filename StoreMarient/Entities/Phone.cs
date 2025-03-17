namespace StoreMarient.Entities
{
    public class Phone: BasicEntity
    {
        public required string Model { get; set; }

        public int Quantity { get; set; }

        public int PieceId { get; set; }
        public virtual Piece Piece { get; set; }
    }
}
