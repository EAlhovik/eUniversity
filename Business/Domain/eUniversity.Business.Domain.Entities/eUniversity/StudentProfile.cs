﻿using System;
using System.Collections.Generic;
using eUniversity.Business.Domain.Entities.Base;

namespace eUniversity.Business.Domain.Entities.eUniversity
{
    /// <summary>
    /// The student entity
    /// </summary>
    public class StudentProfile : Profile
    {
        public DateTime DateOfAdmission { get; set; }

        public virtual Group Group { get; set; }

        public long GroupId { get; set; }

        public virtual ICollection<StudentTheme> Themes { get; set; }
    }
}