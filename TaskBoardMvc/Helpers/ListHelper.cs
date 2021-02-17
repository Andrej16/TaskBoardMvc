using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using TaskBoardMvc.Models;

namespace TaskBoardMvc.Helpers
{
    public static class ListHelper
    {
        public static string List(this HtmlHelper helper, string id, string content, string url, object htmlAttributes)
        {
            TagBuilder tag = new TagBuilder("li");
            tag.GenerateId(id);
            tag.SetInnerText(content);
            tag.MergeAttribute("href", url);
            tag.MergeAttributes(new RouteValueDictionary(htmlAttributes));

            return tag.ToString();
        }
        //public static string List(this HtmlHelper helper, string id, WorkItem workItems)
        //{
        //    TagBuilder tag = new TagBuilder("li");
        //    tag.GenerateId(id);
        //    tag.SetInnerText(content);
        //    tag.MergeAttribute("href", url);
        //    tag.MergeAttributes(new RouteValueDictionary(htmlAttributes));

        //    return tag.ToString();
        //}

    }
}