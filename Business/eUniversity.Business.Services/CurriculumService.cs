﻿using System;
using System.Linq;
using eUniversity.Business.Domain.Contracts;
using eUniversity.Business.Domain.Entities.eUniversity;
using eUniversity.Business.Helpers;
using eUniversity.Business.Services.Base;
using eUniversity.Data.Contracts;

namespace eUniversity.Business.Services
{
    /// <summary>
    /// Represents curriculum service
    /// </summary>
    public class CurriculumService : BaseService<Curriculum>, ICurriculumService
    {
        public CurriculumService(ICurriculumRepository repository)
            : base(repository)
        {
        }

        public new Curriculum CreateOrOpen(long? id)
        {
            if (id == null || id.Value == 0)
            {
                return CreateItem();
            }
            var item = Repository.GetById(id.Value);
            return item ?? CreateItem();
        }

        protected override Curriculum CreateItem()
        {
            return new Curriculum
            {
                Semesters = Enumerable.Range(1, 8)
                                .Select(p => new Semester() { Sequential = p })
                                .ToList(),
                DateOfEnactment = DateTime.Today
            };
        }

        protected override SelectedItemModel CreateSelectedItem(Curriculum item)
        {
            throw new NotImplementedException();
        }
    }
}