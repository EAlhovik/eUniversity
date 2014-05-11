using eUniversity.Business.Domain.Contracts;
using eUniversity.Business.Domain.Entities.eUniversity;
using eUniversity.Business.Services.Base;
using eUniversity.Data.Contracts;
using eUniversity.Data.Entities;

namespace eUniversity.Business.Services
{
    public class StudentProfileService : BaseService<StudentProfile>, IStudentProfileService
    {
        public StudentProfileService(IRepository<StudentProfile> repository, IAuthorizationService authorizationService = null) : base(repository, authorizationService)
        {
        }

        protected override SelectedItemModel CreateSelectedItem(StudentProfile item)
        {
            throw new System.NotImplementedException();
        }
    }
}