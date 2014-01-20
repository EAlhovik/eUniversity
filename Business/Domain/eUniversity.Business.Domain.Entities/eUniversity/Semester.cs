﻿using System.Collections.Generic;
using eUniversity.Business.Domain.Entities.Base;

namespace eUniversity.Business.Domain.Entities.eUniversity
{
    /// <summary>
    /// The semestr entity
    /// </summary>
    public class Semester : Entity
    {
        public virtual ICollection<Subject> Subjects { get; set; }
        public virtual Сurriculum Сurriculum { get; set; }
        public long CurriculaId { get; set; }
    }
}