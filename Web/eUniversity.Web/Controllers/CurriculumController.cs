using eUniversity.Business.Domain.Contracts;
using eUniversity.Business.ViewModels.Curriculum;
using eUniversity.Web.Infrastructure.Controllers;

namespace eUniversity.Web.Controllers
{
    public class CurriculumController : BaseEntityModificationController<CurriculumViewModel, CurriculumRowViewModel>
    {
        public CurriculumController(ICurriculumManagementService curriculumManagementService)
            : base(curriculumManagementService)
        {
        }
    }
}
