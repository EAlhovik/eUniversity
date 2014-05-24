using System;
using eUniversity.Business.Domain.Entities.eUniversity;

namespace eUniversity.Business.Domain.Contracts
{
    /// <summary>
    /// Interface for curriculum service
    /// </summary>
    public interface ICurriculumService : IBaseService<Curriculum>
    {
        Curriculum GetCurriculumForStudent(long specializationId, DateTime dateOfAdmission);
        Curriculum GetCurriculumForStudent(long studentId);
    }
}