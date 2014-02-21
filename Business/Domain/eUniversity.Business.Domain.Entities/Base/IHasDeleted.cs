namespace eUniversity.Business.Domain.Entities.Base
{
    /// <summary>
    /// Interface for entitied that doesn't removed from db
    /// </summary>
    public interface IHasDeleted
    {
        bool IsDeleted { get; set; }
    }
}