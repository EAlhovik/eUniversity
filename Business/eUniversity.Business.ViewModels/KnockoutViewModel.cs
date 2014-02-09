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
    }
}