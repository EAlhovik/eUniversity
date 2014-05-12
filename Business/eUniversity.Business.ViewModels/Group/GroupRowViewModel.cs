using System;
using System.Globalization;
using eUniversity.Business.ViewModels.Base;

namespace eUniversity.Business.ViewModels.Group
{
    /// <summary>
    /// View model for group row view model
    /// </summary>
    public class GroupRowViewModel : KnockoutViewModel, IViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
        public string SpecializationId { get; set; }

        public string DateOfAdmissionDisplay { get; set; }

        public DateTime DateOfAdmission
        {
            get
            {
                if (string.IsNullOrEmpty(DateOfAdmissionDisplay))
                {
                    return DateTime.Now;
                }

                return DateTime.ParseExact(DateOfAdmissionDisplay, DateFormat, CultureInfo.InvariantCulture);
            }
            set
            {
                DateOfAdmissionDisplay = value.ToString(DateFormat);
            }
        }

        private const string DateFormat = "yyyy-MM-dd";
    }
}