//-----------------------------------------------------------------------
// <summary>
// UltraWebGridPatcher class.
// </summary>
// <copyright file="UltraWebGridPatcher.cs" company="Shubhadeep Dhar">
//     Copyright (c) Shubhadeep Dhar. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace UltraWebGridPatch
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Web;
    using System.Web.UI;

    using Infragistics.WebUI.UltraWebGrid;

    /// <summary>
    /// UltraWebGridPatcher class.
    /// </summary>
    /// <remarks>
    /// This class was created with the purpose of patching the Infragistics
    /// UltraWebGrid control to recognize newer browsers.
    /// </remarks>
    public static class UltraWebGridPatcher
    {    
        /// <summary>
        /// Apply UltraWebGrid patch to the page. 
        /// </summary>
        /// <example> This sample shows how to call the PatchUltraWebGrid method
        /// on the Page (MasterPage if required more widely.
        /// <code>
        ///         protected override void OnPreRender(EventArgs e)
        ///         {
        ///             base.OnPreRender(e);
        ///             if (!Page.IsPostBack)
        ///             {
        ///                 bool ultraWebGridPatchStatus = 
        ///                      UltraWebGridPatcher.PatchUltraWebGrid(this.Page);
        ///             }
        /// 
        ///         }
        /// </code>
        /// </example>
        /// <param name="page">Page to be patched.</param>
        /// <returns>True if the page was patched.</returns>
        public static bool PatchUltraWebGrid(Page page)
        {
            if (page != null)
            {
                if (UltraWebGridUpgadeRequiredForBrowser(page.Request.Browser))
                {
                    UpdateUltraWebGridBrowserLevel(page);
                    return true;
                }
            }
            
            return false;
        }
        
        /// <summary>
        /// Whether the browser is configured for applying
        /// UltraWebGrid upgrade.
        /// </summary>
        /// <param name="browser">Browser capabilities object.</param>
        /// <returns>True if the browser is configured for upgrade.</returns>
        private static bool UltraWebGridUpgadeRequiredForBrowser(HttpBrowserCapabilities browser)
        {
            if (browser != null)
            {
                IEnumerable<string> browsersConfigured = BrowsersToUpgradeUltraWebGridFor();
                if (browsersConfigured != null)
                {
                    return ListContainsAnyOfTheItems(browsersConfigured, 
                                             new List<string>()
                                             {
                                                 browser.Browser,
                                                 browser.Type
                                             }, 
                                             StringComparer.InvariantCultureIgnoreCase);
                }
            }
            
            return false;
        }
        
        /// <summary>
        /// Recurse through child controls of UltraWebGrid type 
        /// applying the browser-level patch.
        /// </summary>
        /// <param name="control">The control to recurse into.</param>
        private static void UpdateUltraWebGridBrowserLevel(Control control)
        {
            if (control != null)
            {
                foreach (Control c in control.Controls) 
                {
                    if (c.GetType() == typeof(UltraWebGrid)) 
                    { 
                        ((UltraWebGrid)c).Browser = BrowserLevel.UpLevel; 
                    }
                    
                    UpdateUltraWebGridBrowserLevel(c);
                }
            }
        }
    
        /// <summary>
        /// List of browsers for which UltraWebGrid control needs to be patched.
        /// </summary>
        /// <returns>List of browsers from configuration key.</returns>
        private static IEnumerable<string> BrowsersToUpgradeUltraWebGridFor()
        {
            string browsersInConfig = ConfigurationManager.AppSettings.Get("UltraWebGridUpgradeBrowsers");
            if (!string.IsNullOrWhiteSpace(browsersInConfig))
            {
                return browsersInConfig.Split(',')
                       .Select(x => x.Trim());
            }
            
            return null;
        }

        /// <summary>
        /// Generic method to check if one list contains any item from another list.
        /// </summary>
        /// <param name="list">The list in which items are to be searched.</param>
        /// <param name="items">The items to be searched int the list.</param>
        /// <param name="comparer">An IEqualityComparer object for the type.</param>
        /// <returns>True if the list contains any of the items.</returns>
        private static bool ListContainsAnyOfTheItems<T>(IEnumerable<T> list, 
                                                 IEnumerable<T> items, 
                                                 IEqualityComparer<T> comparer)
        {
            return items.Any(x => list.Contains(x, comparer));
        }
    }
}