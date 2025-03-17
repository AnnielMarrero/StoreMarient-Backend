namespace StoreMarient.Entities
{
    public class Product : BasicEntity
    {
        public required string Name { get; set; }

        public int Quantity { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; } 
    }
}
