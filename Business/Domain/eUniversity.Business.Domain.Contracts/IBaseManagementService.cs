using System.Collections.Generic;
using eUniversity.Business.ViewModels.Base;

namespace eUniversity.Business.Domain.Contracts
{
    public interface IBaseManagementService<TViewModel, TRowViewModel>
        where TViewModel : class, IViewModel
        where TRowViewModel : class, IViewModel
    {
        TViewModel Open(long? id);
        void Save(TViewModel curriculum);

        void Save(IEnumerable<TRowViewModel> viewModels);

        IEnumerable<TRowViewModel> GetRows();

        void Remove(IEnumerable<TRowViewModel> viewModels);
    }
}