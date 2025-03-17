namespace StoreMarient.Entities
{
    public class Mica: BasicEntity
    {
        public required string Model { get; set; }

        public int Quantity { get; set; }

        public int PhoneTypeId { get; set; }
        public virtual PhoneType PhoneType { get; set; }
    }
}
