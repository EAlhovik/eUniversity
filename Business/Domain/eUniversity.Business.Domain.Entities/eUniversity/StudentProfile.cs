using System;
using eUniversity.Business.Domain.Entities.Base;

namespace eUniversity.Business.Domain.Entities.eUniversity
{
    /// <summary>
    /// The student entity
    /// </summary>
    public class StudentProfile : Profile
    {
        public string GroupName { get; set; }
        public DateTime? QwEweTime { get; set; }
    }
}