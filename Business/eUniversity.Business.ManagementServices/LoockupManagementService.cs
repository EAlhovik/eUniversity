﻿using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using eUniversity.Business.Domain.Contracts;
using eUniversity.Business.Domain.Entities.Enums;
using eUniversity.Business.Domain.Entities.eUniversity;
using eUniversity.Business.Helpers;
using eUniversity.Business.ViewModels;
using eUniversity.Business.ViewModels.Curriculum;
using eUniversity.Common.Utilities;
using eUniversity.Data.Entities;

namespace eUniversity.Business.ManagementServices
{
    /// <summary>
    /// Represents management service
    /// </summary>
    public class LoockupManagementService : ILoockupManagementService
    {
        private readonly ISpecialityService specialityService;
        private readonly ISpecializationService specializationService;
        private readonly IProfessorProfileService professorProfileService;
        private readonly IGroupService groupService;
        private readonly ISubjectService subjectService;
        private readonly IThemeService themeService;

        public LoockupManagementService(ISpecialityService specialityService, ISpecializationService specializationService, IProfessorProfileService professorProfileService, IGroupService groupService, ISubjectService subjectService, IThemeService themeService)
        {
            this.specialityService = specialityService;
            this.specializationService = specializationService;
            this.professorProfileService = professorProfileService;
            this.groupService = groupService;
            this.subjectService = subjectService;
            this.themeService = themeService;
        }

        #region ILoockupManagementService Members

        /// <summary>
        /// Gets the specialities.
        /// </summary>
        /// <param name="term">The term.</param>
        /// <returns> specialities by term </returns>
        public IEnumerable<SelectedItemViewModel> GetSpecialities(string term)
        {
            var specialities = specialityService.GetSelectedItems(term)
                .Select(Mapper.Map<SelectedItemModel, SelectedItemViewModel>);
            return specialities;
        }

        public IEnumerable<SelectedItemViewModel> GetGroups(string term)
        {
            var groups = groupService.GetSelectedItems(term)
                .Select(Mapper.Map<SelectedItemModel, SelectedItemViewModel>);
            return groups;
        }

        /// <summary>
        /// Gets the speciality.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public SelectedItemViewModel GetSpeciality(long? id)
        {
            var speciality = specialityService.CreateOrOpen(id);
            return Mapper.Map<Speciality, SelectedItemViewModel>(speciality);
        }

        public SelectedItemViewModel GetSpecialization(long? id)
        {
            var speciality = specializationService.CreateOrOpen(id);
            return Mapper.Map<Specialization, SelectedItemViewModel>(speciality);
        }

        public IEnumerable<SelectedItemViewModel> GetSpecializations(string term)
        {
            return specializationService.GetSelectedItems(term)
                .Select(Mapper.Map<SelectedItemModel, SelectedItemViewModel>);
        }

        public IEnumerable<SelectedItemViewModel> GetProfessors(string term)
        {
            return professorProfileService.GetProfessors(term).Select(Mapper.Map<SelectedItemModel, SelectedItemViewModel>);
        }

        public IEnumerable<SelectedItemViewModel> GetSemesters(string term)
        {
            var values = EnumHelper.GetEnumValues(typeof(SemesterEnum)).Select(p => new SelectedItemViewModel { Id = p.Key, Text = p.Value });
            return string.IsNullOrEmpty(term) ? values : values.Where(s => s.Text.Contains(term));
        }

        public IEnumerable<SelectedItemViewModel> GetSubjects(string term)
        {
            return subjectService.GetSelectedItems(term).Select(Mapper.Map<SelectedItemModel, SelectedItemViewModel>);
        }

        public string GetThemeDescription(long id)
        {
            var theme = themeService.CreateOrOpen(id);
            return theme == null ? string.Empty : theme.Description;
        }

        public SelectedItemViewModel GetSubject(string id)
        {
            long parseResult;
            if (long.TryParse(id, out parseResult))
            {
                return GetSubject(parseResult);
            }
            else if (!string.IsNullOrEmpty(id))
            {
                var subject = new SelectedItemViewModel()
                {
                    Id = id,
                    Text = SubjectIdPrefixHelper.Trim(id)
                };
                return subject;
            }

            return null;
        }

        public IEnumerable<SelectedItemViewModel> GetSubjectTypes(bool isLast)
        {
            var subjectTypes = EnumHelper.GetEnumValues(typeof(SubjectTypeEnum));
            if (isLast)
            {
                return subjectTypes
                    .Where(p => p.Key == ((int)SubjectTypeEnum.Diplom).ToString())
                    .Select(p => new SelectedItemViewModel { Id = p.Key, Text = p.Value });
            }
            return subjectTypes
                    .Where(p => p.Key != ((int)SubjectTypeEnum.Diplom).ToString())
                    .Select(p => new SelectedItemViewModel { Id = p.Key, Text = p.Value });
        }

        public SelectedItemViewModel GetSubjectType(string id)
        {
            var type = EnumHelper.GetEnumValues(typeof(SubjectTypeEnum))
                .FirstOrDefault(p => p.Key == id);
            return new SelectedItemViewModel { Id = type.Key, Text = type.Value };
        }

        public IEnumerable<SelectedItemViewModel> GetThemes(string term)
        {
            return themeService.GetSelectedItems(term)
                .Select(Mapper.Map<SelectedItemModel, SelectedItemViewModel>); ;
        }

        public SelectedItemViewModel GetTheme(string id)
        {
            long parseResult;
            if (long.TryParse(id, out parseResult))
            {
                return GetTheme(parseResult);
            }
            else if (!string.IsNullOrEmpty(id))
            {
                var theme = new SelectedItemViewModel()
                {
                    Id = id,
                    Text = SubjectIdPrefixHelper.Trim(id)
                };
                return theme;
            }
            return null;
        }

        #endregion

        private SelectedItemViewModel GetTheme(long id)
        {
            return Mapper.Map<SelectedItemModel, SelectedItemViewModel>(themeService.GetSelectedItemById(id));
        }

        private SelectedItemViewModel GetSubject(long parseResult)
        {
            return Mapper.Map<SelectedItemModel, SelectedItemViewModel>(subjectService.GetSelectedItemById(parseResult));
        }
    }
}