﻿using System.Linq;
using AutoMapper;
using eUniversity.Business.Domain.Contracts;
using eUniversity.Business.Domain.Entities.eUniversity;
using eUniversity.Business.ManagementServices.Base;
using eUniversity.Business.ViewModels;
using eUniversity.Business.ViewModels.Curriculum;
using eUniversity.Data.Contracts;

namespace eUniversity.Business.ManagementServices
{
    /// <summary>
    /// Represents curriculum management service
    /// </summary>
    public class CurriculumManagementService : BaseManagementService<CurriculumRowViewModel, Curriculum>, ICurriculumManagementService
    {
        private readonly ISemesterManagementService semesterManagementService;

        public CurriculumManagementService(ISemesterManagementService semesterManagementService,
            ICurriculumService curriculumService, IEUniversityUow eUniversityUow):base(eUniversityUow,curriculumService)
        {
            this.semesterManagementService = semesterManagementService;
        }

        public CurriculumViewModel Open(long? id)
        {
            var item = Service.CreateOrOpen(id);
            var viewModel = Mapper.Map<Curriculum, CurriculumViewModel>(item);
            return viewModel;
        }

        public void Save(CurriculumViewModel viewModel)
        {
            var curriculum = new Curriculum() { Id = viewModel.Id };
            UpdateModel(viewModel, curriculum);

            semesterManagementService.Save(viewModel.Semesters, curriculum);

            UnitOfWork.Commit();
        }

        public CurriculumViewModel CreateCurriculum(SelectedItemViewModel viewModel)
        {
            var curriculum = new CurriculumViewModel()
            {
                CurriculumHeader = new CurriculumHeaderViewModel()
                {
                    CountSemesters = viewModel
                }
            };
            int count = int.Parse(viewModel.Id);
            curriculum.Semesters = semesterManagementService.CreateSemesters(count);
            return curriculum;
        }

        private void UpdateModel(CurriculumViewModel viewModel, Curriculum curriculum)
        {
            Service.Save(curriculum);
            Mapper.Map<CurriculumViewModel, Curriculum>(viewModel, curriculum);
        }
    }
}