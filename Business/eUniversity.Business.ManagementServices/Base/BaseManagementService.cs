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
    /// <typeparam name="TViewModel">The type of the view model.</typeparam>
    /// <typeparam name="TRowViewModel">The type of the row view model.</typeparam>
    /// <typeparam name="TModel"></typeparam>
    public class BaseManagementService<TViewModel, TRowViewModel, TModel>
        where TViewModel : class, IViewModel
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

        public TViewModel Open(long? id)
        {
            var item = Service.CreateOrOpen(id);
            var viewModel = Mapper.Map<TModel, TViewModel>(item);
            return viewModel;
        }

        public virtual void Save(TViewModel viewModel)
        {
            var entity = Service.CreateOrOpen(viewModel.Id);
            Mapper.Map<TViewModel, TModel>(viewModel, entity);
            Service.Save(entity);
            UnitOfWork.Commit();
        }

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
            var listViewModels = Service.All().Select(Mapper.Map<TModel, TRowViewModel>);
            return listViewModels;
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