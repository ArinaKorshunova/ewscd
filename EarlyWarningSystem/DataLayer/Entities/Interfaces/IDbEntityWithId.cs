namespace DataLayer.Entities.Interfaces
{
    public interface IDbEntityWithId : IDbEntity
    {
        long Id { get; set; }
    }
}
