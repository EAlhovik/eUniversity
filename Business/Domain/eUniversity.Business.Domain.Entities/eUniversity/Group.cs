using System.Collections.Generic;
using System.Net.Sockets;
using eUniversity.Business.Domain.Entities.Base;

namespace eUniversity.Business.Domain.Entities.eUniversity
{
    /// <summary>
    /// The group entity
    /// </summary>
    public class Group : Entity
    {
        public string Name { get; set; }

        public long SpecializationsId { get; set; }

        public virtual ICollection<Specialization> Specializations { get; set; }
    }
}