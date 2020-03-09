using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages;

namespace FinalTask.Models
{
    public static class WebPageHelper
    {
        public static void PropogateSection(this WebPageBase page, string sectionName)
        {
            if (page.IsSectionDefined(sectionName))
            {
                page.DefineSection(sectionName, delegate () { page.Write(page.RenderSection(sectionName)); });
            }
        }
    }
}