using System.Collections.Generic;

namespace eUniversity.Business.ViewModels
{
    /// <summary>
    /// View model for ajax results
    /// </summary>
    public class AjaxViewModel
    {
        public object Data { get; set; }

        private IEnumerable<string> errors;
        public IEnumerable<string> Errors
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
    }
}