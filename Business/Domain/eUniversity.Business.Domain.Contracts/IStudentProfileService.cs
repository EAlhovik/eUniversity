using System;
using eUniversity.Business.Domain.Entities.eUniversity;

namespace eUniversity.Business.Domain.Contracts
{
    /// <summary>
    /// Interface for student profile
    /// </summary>
    public interface IStudentProfileService : IBaseService<StudentProfile>
    {
        Specialization GetUserSpecialization(long profileId);
        DateTime GetDateOfAdmission(long id);
        Group GetUserGroup(long userId);
    }
}