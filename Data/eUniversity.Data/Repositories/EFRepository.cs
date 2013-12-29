using System;
using System.Data.Entity;
using System.Linq;
using eUniversity.Business.Domain.Entities.Base;
using eUniversity.Data.Contracts;

namespace eUniversity.Data.Repositories
{
    public class EFRepository<T> : IRepository<T> where T : class, IEntity
    {
        public EFRepository(EUniversityDbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException("dbContext");
            }
            DbContext = dbContext;
        }

        /// <summary>
        /// Gets or sets dbcontext
        /// </summary>
        protected DbContext DbContext { get; set; }

        /// <summary>
        /// Gets or sets dbset
        /// </summary>
        protected IDbSet<T> DbSet
        {
            get
            {
                return DbContext.Set<T>();
            }
        }

        #region IRepository<T> Members

        /// <summary>
        /// Gets all the entities of type T
        /// </summary>
        /// <returns>Result set of all the entities</returns>
        public virtual IQueryable<T> All()
        {
            return DbSet;
        }

        /// <summary>
        /// Gets entity from repository by id.
        /// </summary>
        /// <param name="id">System identifier of entity in application.</param>
        /// <returns>Returns loaded entity or null.</returns>
        public virtual T GetById(long id)
        {
            return DbSet.Find(id);
        }

        /// <summary>
        /// Saves entity in the repository.
        /// </summary>
        /// <param name="entity">Entity to save.</param>
        public virtual void InsertOrUpdate(T entity, bool startTrackProperties = false)
        {
            if (IsNew(entity))
            {
                DbSet.Add(entity);
            }

            AttachForUpdate(entity, startTrackProperties);

            SaveProperty(entity);
        }

        private static void SaveProperty(T entity)
        {
            if (entity is IEntityChanged)
            {
                if (entity.IsNew())
                {
                    ((IEntityChanged)entity).Created = DateTime.Now;
                    ((IEntityChanged)entity).CreatedBy = "base me";
                }
            }
        }

        /// <summary>
        /// Deletes entity from repository.
        /// </summary>
        /// <param name="entity">Entity to delete.</param>
        public virtual void Delete(T entity)
        {
            DbSet.Attach(entity);
            DbContext.Entry(entity).State = EntityState.Deleted;
            DbSet.Remove(entity);
        }

        /// <summary>
        /// Deletes entity by mathing id.
        /// </summary>
        /// <param name="id"></param>
        public virtual void Delete(long id)
        {
            DbSet.Remove(GetById(id));
        }

        #endregion

        /// <summary>
        /// Attaches entity to context and marks it as updated for EF to update.
        /// </summary>
        /// <param name="entity">Entity to attach.</param>
        /// <typeparam name="T">Type of entity to attach.</typeparam>
        protected void AttachForUpdate<T>(T entity, bool startTrackProperties) where T : class, IEntity
        {
            if (IsNew(entity))
            {
                return;
            }

            if (!IsAttached(entity))
            {
                DbContext.Set<T>().Attach(entity);
                if (!startTrackProperties)
                {
                    DbContext.Entry(entity).State = EntityState.Modified;
                }
            }
        }

        /// <summary>
        /// Checks if entity is new.
        /// </summary>
        /// <param name="entity">Entity to check.</param>
        /// <typeparam name="T">Type of entity to attach.</typeparam>
        /// <returns>Returns a value indicating whether provided entity is new (not added previously).</returns>
        protected bool IsNew<T>(T entity) where T : class, IEntity
        {
            return entity.Id == 0;
        }

        /// <summary>
        /// Checks if entity already attached.
        /// </summary>
        /// <permission cref="System.Security.PermissionSet">public</permission>
        /// <param name="entity">Entity to check.</param>
        /// <typeparam name="ET">Entity type.</typeparam>
        /// <returns>A value indicating whether entity already attached.</returns>
        protected bool IsAttached<T>(T entity) where T : class, IEntity
        {
            return DbContext.Set<T>().Local.Contains(entity);
        }
    }

}