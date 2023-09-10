namespace WTM.CarManager.Business.Domains.Models
{
    public abstract class Entity
    {
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public Entity()
        {
            Id = Guid.NewGuid();

        }
        protected virtual bool IsValid()
        {
            throw new NotImplementedException();
        }
    }

}
