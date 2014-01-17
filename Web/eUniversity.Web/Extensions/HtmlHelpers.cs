using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;

namespace eUniversity.Web.Extensions
{
    public static class HtmlHelpers
    {
        #region RawActionLink

        private const string Replace = "[replace]";

        public static MvcHtmlString RawActionLink(this HtmlHelper htmlHelper, string linkText, string actionName,
                                                  string controllerName)
        {
            var lnk = htmlHelper.ActionLink(Replace, actionName, controllerName);
            return MvcHtmlString.Create(lnk.ToHtmlString().Replace(Replace, linkText));
        }

        public static MvcHtmlString RawActionLink(this AjaxHelper ajaxHelper, string linkText, string actionName,
                                                  string controllerName, AjaxOptions ajaxOptions)
        {
            var lnk = ajaxHelper.ActionLink(Replace, actionName, controllerName, ajaxOptions);
            return MvcHtmlString.Create(lnk.ToString().Replace(Replace, linkText));
        }

        #endregion


        #region EnumDropDownListFor
        /// <summary>
        /// Enums the drop down list for.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcHtmlString EnumDropDownListFor<TModel, TEnum>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TEnum>> expression, object htmlAttributes)
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            Type enumType = GetNonNullableModelType(metadata);
            IEnumerable<TEnum> values = Enum.GetValues(enumType).Cast<TEnum>();

            IEnumerable<SelectListItem> items = from value in values
                                                select new SelectListItem
                                                {
                                                    Text = GetEnumDescription(value),
                                                    Value = value.ToString(),
                                                    Selected = value.Equals(metadata.Model)
                                                };

            // If the enum is nullable, add an 'empty' item to the collection
            if (metadata.IsNullableValueType)
                items = SingleEmptyItem.Concat(items);

            return htmlHelper.DropDownListFor(expression, items, htmlAttributes);
        }
        private static readonly SelectListItem[] SingleEmptyItem = new[] { new SelectListItem { Text = string.Empty, Value = string.Empty } };
        private static string GetEnumDescription<TEnum>(TEnum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if ((attributes != null) && (attributes.Length > 0))
                return attributes[0].Description;
            else
                return value.ToString();
        }

        private static Type GetNonNullableModelType(ModelMetadata modelMetadata)
        {
            Type realModelType = modelMetadata.ModelType;

            Type underlyingType = Nullable.GetUnderlyingType(realModelType);
            if (underlyingType != null)
            {
                realModelType = underlyingType;
            }
            return realModelType;
        }

        #endregion

    }
}