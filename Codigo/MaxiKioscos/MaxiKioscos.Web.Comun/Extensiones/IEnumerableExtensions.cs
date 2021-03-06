﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Dely.Core.Web.Utils
{
    /// <summary>
    /// Contains extensions for IEnumerable
    /// </summary>
    public static class IEnumerableExtensions
    {
        /// <summary>
        /// Create a collection of SelectListItem to be used in a drop down.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <param name="selectedId">Selected identifier</param>
        /// <param name="getId">Func that return the id from each item</param>
        /// <param name="getText">Func that return the text for each item</param>
        /// <param name="getValue">Func that return the value for each item</param>
        /// <returns>Collection of SelectListItem created from the items</returns>
        public static IEnumerable<SelectListItem> ToSelectListItem<T>(this IEnumerable<T> items,
                                                                      int? selectedId, Func<T, int> getId,
                                                                      Func<T, string> getText, 
                                                                      Func<T, string> getValue)
        {
            return
                items.Select(item =>
                            new SelectListItem
                                {
                                    Selected = (getId(item) == selectedId),
                                    Text = getText(item),
                                    Value = getValue(item)
                                });
        }

        /// <summary>
        /// Create a collection of SelectListItem to be used in a drop down.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <param name="selectedId">Selected identifier as GUID</param>
        /// <param name="getId">Func that return the id from each item</param>
        /// <param name="getText">Func that return the text for each item</param>
        /// <param name="getValue">Func that return the value for each item</param>
        /// <returns>Collection of SelectListItem created from the items</returns>
        public static IEnumerable<SelectListItem> ToSelectListItem<T>(this IEnumerable<T> items,
                                                                      Guid? selectedId, Func<T, Guid> getId,
                                                                      Func<T, string> getText,
                                                                      Func<T, string> getValue)
        {
            return
                items.Select(item =>
                            new SelectListItem
                            {
                                Selected = (getId(item) == selectedId),
                                Text = getText(item),
                                Value = getValue(item)
                            });
        }
    }
}
