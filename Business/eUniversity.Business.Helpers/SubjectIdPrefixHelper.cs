namespace eUniversity.Business.Helpers
{
    /// <summary>
    /// Helper for set and trim prefix from subject id
    /// </summary>
    public static class SubjectIdPrefixHelper
    {
        public static string Trim(string id)
        {
            return id.TrimEnd(SubjectIdPrefix);
        }

        public const char SubjectIdPrefix = '+';
    }
}