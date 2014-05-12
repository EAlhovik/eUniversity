using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using eUniversity.Business.Domain.Contracts;
using eUniversity.Business.Domain.Entities.Base;
using eUniversity.Business.ViewModels.Base;
using eUniversity.Data.Contracts;

namespace eUniversity.Business.ManagementServices.Base
{
    /// <summary>
    /// Represents base management service
    /// </summary>
    /// <typeparam name="TRowViewModel">The type of the row view model.</typeparam>
    /// <typeparam name="TModel"></typeparam>
    public class BaseManagementService<TRowViewModel, TModel>
        where TRowViewModel : class, IViewModel
        where TModel : class, IEntity
    {
        protected readonly IEUniversityUow UnitOfWork;
        protected readonly IBaseService<TModel> Service;

        public BaseManagementService(IEUniversityUow unitOfWork, IBaseService<TModel> service)
        {
            UnitOfWork = unitOfWork;
            Service = service;
        }

        #region IBaseManagementService Members

        public void Save(IEnumerable<TRowViewModel> viewModels)
        {
            foreach (var viewModel in viewModels)
            {
                var entity = Service.CreateOrOpen(viewModel.Id);
                Mapper.Map<TRowViewModel, TModel>(viewModel, entity);
                Service.Save(entity);
            }
            UnitOfWork.Commit();
        }

        public IEnumerable<TRowViewModel> GetRows()
        {
            var listViewModels = Service.All().ToList().Select(Mapper.Map<TModel, TRowViewModel>);
            return listViewModels.ToList();
        }

        public void Remove(IEnumerable<TRowViewModel> viewModels)
        {
            foreach (var viewModel in viewModels)
            {
                var entity = Service.CreateOrOpen(viewModel.Id);
                Mapper.Map<TRowViewModel, TModel>(viewModel, entity);
                Service.Delete(entity);
            }
            UnitOfWork.Commit();
        }

        #endregion
    }
}