namespace StoreMarient.Entities
{
    public class Cover: BasicEntity
    {
        public required string Model { get; set; }
       
        public int PhoneTypeId { get; set; }
        public virtual PhoneType PhoneType { get; set; }
    }
}
