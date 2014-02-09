using System.Collections.Generic;

namespace eUniversity.Business.ViewModels
{
    /// <summary>
    /// View model for grid
    /// </summary>
    public class GridViewModel
    {
        public IEnumerable<object> Rows { get; set; }
    }
}