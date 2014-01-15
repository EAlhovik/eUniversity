using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using eUniversity.Business.Domain.Contracts;
using eUniversity.Business.Domain.Entities.eUniversity;
using eUniversity.Data.Contracts;

namespace eUniversity.Business.Services
{
    /// <summary>
    /// Represents speciality service
    /// </summary>
    public class SpecialityService : ISpecialityService
    {
        private readonly IRepository<Speciality> specialityRepository;

        public SpecialityService(IRepository<Speciality> specialityRepository)
        {
            this.specialityRepository = specialityRepository;
        }

        #region ISpecialityService Members

        /// <summary>
        /// Opens the specified identifier.
        /// </summary>
        /// <param name="id">The identifier of entity.</param>
        /// <returns>
        /// The Speciality entity. Null if entity doesn't exist
        /// </returns>
        public Speciality CreateOrOpen(long? id)
        {
            if (id == null || id.Value == 0)
            {
                return CreateSpeciality();
            }
            var speciality = specialityRepository.GetById(id.Value);
            return speciality ?? CreateSpeciality();
        }
        
        /// <summary>
        /// Saves the specified speciality.
        /// </summary>
        /// <param name="speciality">The speciality.</param>
        public void Save(Speciality speciality)
        {
            specialityRepository.InsertOrUpdate(speciality, true);
            if (speciality.IsNew())
            {
                UpdateHistoryInformation(speciality);
            }

        }

        /// <summary>
        /// Alls this instance.
        /// </summary>
        /// <returns>
        /// All specialities
        /// </returns>
        public IEnumerable<Speciality> All()
        {
            return specialityRepository.All();
        }

        #endregion

        private Speciality CreateSpeciality()
        {
            return new Speciality();
        }

        private void UpdateHistoryInformation(Speciality speciality)
        {
        }
    }
}