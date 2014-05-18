using eUniversity.Business.Domain.Contracts;
using eUniversity.Business.Domain.Entities.eUniversity;
using eUniversity.Business.Services.Base;
using eUniversity.Data.Contracts;
using eUniversity.Data.Entities;

namespace eUniversity.Business.Services
{
    public class StudentThemeService : BaseService<StudentTheme>, IStudentThemeService
    {
        public StudentThemeService(IRepository<StudentTheme> repository, IAuthorizationService authorizationService = null) : base(repository, authorizationService)
        {
        }

        protected override SelectedItemModel CreateSelectedItem(StudentTheme item)
        {
            throw new System.NotImplementedException();
        }
    }
}