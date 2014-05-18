using System.Collections.Generic;
using System.Linq;

namespace eUniversity.Business.ViewModels
{
    /// <summary>
    /// View model for ajax results
    /// </summary>
    public class AjaxViewModel
    {
        public object Data { get; set; }

        private ICollection<string> errors;
        public ICollection<string> Errors
        {
            get
            {
                return errors?? (errors = new List<string>());
            }
            set
            {
                errors = value;
            }
        }

        public bool IsValid
        {
            get
            {
                return Errors == null || !Errors.Any();
            }
        }
    }
}