using System;

namespace eUniversity.Business.ViewModels.Curriculum
{
    /// <summary>
    /// View model for curriculum header servition
    /// </summary>
    public class CurriculumHeaderViewModel
    {
        public long Id { get; set; }

        public SelectedItemViewModel Specialization{get;set;}

        public SelectedItemViewModel CountSemesters { get; set; }

        public DateTime DateOfEnactment
        {
            get
            {
                if (string.IsNullOrEmpty(DateOfEnactmentDisplay))
                {
                    DateOfEnactmentDisplay = DateTime.Today.ToShortDateString();
                }
                return DateTime.Parse(DateOfEnactmentDisplay);
            }
            set
            {
                DateOfEnactmentDisplay = value.ToShortDateString();
            }
        }

        public string DateOfEnactmentDisplay { get; set; }
    }
}