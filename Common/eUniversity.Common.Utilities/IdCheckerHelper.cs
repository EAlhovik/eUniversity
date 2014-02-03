namespace eUniversity.Common.Utilities
{
    public static class IdCheckerHelper
    {
         public static bool IsNumber(string id)
         {
             long number;
             return long.TryParse(id, out number);
         }
    }
}