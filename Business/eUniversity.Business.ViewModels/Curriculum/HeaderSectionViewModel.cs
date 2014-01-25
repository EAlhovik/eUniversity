﻿using System;

namespace eUniversity.Business.ViewModels.Curriculum
{
    /// <summary>
    /// View model for curriculum header servition
    /// </summary>
    public class HeaderSectionViewModel
    {
        public long Id { get; set; }
        public long? SpecializationId { get; set; }
        public SemesterEnum CountSemesters { get; set; }

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