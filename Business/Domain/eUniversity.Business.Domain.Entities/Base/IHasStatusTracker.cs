using eUniversity.Business.Domain.Entities.Enums;

namespace eUniversity.Business.Domain.Entities.Base
{
    public interface IHasStatusTracker
    {
        EntityStatusEnum Status { get; set; } 
    }
}