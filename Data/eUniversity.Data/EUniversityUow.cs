using System;
using System.Data.Entity;
using eUniversity.Data.Contracts;

namespace eUniversity.Data
{
    /// <summary>
    /// Represents unity of work for eUniversity db
    /// </summary>
    public class EUniversityUow : IEUniversityUow, IDisposable
    {
        private readonly DbContext dbContext;

        /// <summary>
        /// Creates eticket unity of work with the provided repository provider
        /// </summary>
        /// <param name="context">Db context </param>
        public EUniversityUow(EUniversityDbContext context)
        {
            dbContext = context;
            ConfigureDbContext();
        }

        #region IEUniversityUow Members

        /// <summary>
        /// Commits info from DbContext to database
        /// </summary>
        public void Commit()
        {
            dbContext.SaveChanges();
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose if the appropriate parameter value
        /// </summary>
        /// <param name="disposing">If disposing</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (dbContext != null)
                {
                    dbContext.Dispose();
                }
            }
        }

        #endregion

        /// <summary>
        /// Creates dbcontext for eTicket database
        /// </summary>
        protected void ConfigureDbContext()
        {
            dbContext.Configuration.ProxyCreationEnabled = false;
            dbContext.Configuration.LazyLoadingEnabled = false;
        }
    }
}