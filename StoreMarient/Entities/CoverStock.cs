namespace StoreMarient.Entities
{
    public class CoverStock : BasicEntity
    {
        public int CoverId { get; set; }
        public virtual Cover Cover { get; set; }

        public int CoverTypeId { get; set; }
        public virtual CoverType CoverType { get; set; }

        public int Quantity { get; set; }
    }
}
