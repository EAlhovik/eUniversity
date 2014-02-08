namespace eUniversity.Business.ViewModels.Membership
{
    /// <summary>
    /// View model for user row 
    /// </summary>
    public class UserRowViewModel
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string Created { get; set; }
        public bool IsApproved { get; set; }

    }
}