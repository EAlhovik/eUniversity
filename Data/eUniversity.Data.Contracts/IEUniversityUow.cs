namespace eUniversity.Data.Contracts
{
    /// <summary>
    /// Declares interface for unity or work of eUniversity context
    /// </summary>
    public interface IEUniversityUow
    {
        /// <summary>
        /// Commits info from DbContext to database
        /// </summary>
        void Commit();
    }
}