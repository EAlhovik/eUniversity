using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace eUniversity.Business.ViewModels
{
    /// <summary>
    /// View model for grid
    /// </summary>
    public class GridViewModel
    {
        public IEnumerable<object> Rows { get; set; }

        public string ViewModel
        {
            get
            {
                return Rows.GetType().GetGenericArguments().Single().Name;
            }
        }

        public string Object
        {
            get
            {
                return Regex.Split(ViewModel, @"(?<!^)(?=[A-Z])")[0].ToLower();
            }
        }
    }
}