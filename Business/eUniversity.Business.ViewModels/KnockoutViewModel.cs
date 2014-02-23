using System.Text.RegularExpressions;

namespace eUniversity.Business.ViewModels
{
    /// <summary>
    /// View model for knockout
    /// </summary>
    public class KnockoutViewModel
    {
        public string ViewModel
        {
            get
            {
                return this.GetType().Name;
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