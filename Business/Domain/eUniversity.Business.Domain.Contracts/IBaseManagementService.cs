using System.Collections.Generic;
using eUniversity.Business.ViewModels.Base;

namespace eUniversity.Business.Domain.Contracts
{
    public interface IBaseManagementService<TRowViewModel>
        where TRowViewModel : class, IViewModel
    {
        void Save(IEnumerable<TRowViewModel> viewModels);

        IEnumerable<TRowViewModel> GetRows();

        void Remove(IEnumerable<TRowViewModel> viewModels);
    }
}