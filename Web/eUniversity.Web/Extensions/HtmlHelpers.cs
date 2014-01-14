using System;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;

namespace eUniversity.Web.Extensions
{
    public static class HtmlHelpers
    {
        private const string Replace = "[replace]";

        public static MvcHtmlString RawActionLink(this HtmlHelper htmlHelper, string linkText, string actionName,
                                                  string controllerName)
        {
            var lnk = htmlHelper.ActionLink(Replace, actionName, controllerName);
            return MvcHtmlString.Create(lnk.ToHtmlString().Replace(Replace, linkText));
        }

        public static MvcHtmlString RawActionLink(this AjaxHelper ajaxHelper, string linkText, string actionName, string controllerName, AjaxOptions ajaxOptions)
        {
            var lnk = ajaxHelper.ActionLink(Replace, actionName, controllerName, ajaxOptions);
            return MvcHtmlString.Create(lnk.ToString().Replace(Replace, linkText));
        }
    }
}