using System.Web.Mvc;
using eUniversity.Web.Infrastructure.Filters;

namespace eUniversity.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AuthorizeAttribute());
            filters.Add(new LocalizationAttribute());
        }
    }
}