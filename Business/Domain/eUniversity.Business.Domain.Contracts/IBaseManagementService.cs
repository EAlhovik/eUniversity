using System.Collections.Generic;
using eUniversity.Business.Domain.Entities.Base;

namespace eUniversity.Business.Domain.Contracts
{
    /// <summary>
    /// Base interface for management services
    /// </summary>
    /// <typeparam name="TViewModel">The type of the view model.</typeparam>
    /// <typeparam name="TRowViewModel">The type of the row view model.</typeparam>
    /// <typeparam name="TModel"></typeparam>
    public interface IBaseManagementService<TViewModel, TRowViewModel, TModel>
        where TViewModel : class
        where TRowViewModel : class
        where TModel : class,IEntity
    {
        TViewModel Open(long? id);
        void Save(TViewModel viewModel);

        IEnumerable<TRowViewModel> GetRows();
    }
}