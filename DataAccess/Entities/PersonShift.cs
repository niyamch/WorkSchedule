namespace DataAccess.Entities
{
    public class PersonShift : BaseEntity
    {
        public int PersonId { get; set; }
        public virtual Person Person { get; set; }
        public int ShiftId { get; set; }
        public virtual Shift Shift { get; set; }
    }
}
