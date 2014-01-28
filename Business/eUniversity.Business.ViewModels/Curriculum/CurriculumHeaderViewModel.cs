﻿using System;
using eUniversity.Business.Helpers;

namespace eUniversity.Business.ViewModels.Curriculum
{
    /// <summary>
    /// View model for curriculum header servition
    /// </summary>
    public class CurriculumHeaderViewModel
    {
        public long Id { get; set; }
//        public long? SpecializationId { get; set; }
//        private SelectedItemModel specialization;

        public SelectedItemModel Specialization{get;set;}

        public SelectedItemModel CountSemesters { get; set; }

        public DateTime DateOfEnactment
        {
            get
            {
                return !string.IsNullOrEmpty(DateOfEnactmentDisplay) ? DateTime.Parse(DateOfEnactmentDisplay) : DateTime.Today;
            }
            set
            {
                DateOfEnactmentDisplay = value.ToShortDateString();
            }
        }

        public string DateOfEnactmentDisplay { get; set; }
    }
}