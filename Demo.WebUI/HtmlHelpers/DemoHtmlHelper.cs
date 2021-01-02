using Demo.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Demo.WebUI.HtmlHelpers
{
    public static class DemoHtmlHelper
    {
        public static MvcHtmlString PageLinks(//mvchtmlstring o day de browser hieu la 1 the html nếu xài string thì nó chỉ hiểu là string
            this HtmlHelper helper,
            PagingInfo pagingInfo,
            Func<int,string> pageUrl)
        {
            StringBuilder sb = new StringBuilder();

            int start = Math.Max(pagingInfo.CurentPage - 2, 1);
            int end = Math.Min(start + 5, pagingInfo.TotalPages);
            for(int i=start; i <= end; i++)
            {
                //<a href="ListProduct?page=1">1</a>
                TagBuilder tagA = new TagBuilder("a");
                tagA.SetInnerText(i.ToString());
                tagA.Attributes.Add("href", pageUrl(i));
                tagA.AddCssClass("page-link");

                TagBuilder tagLi = new TagBuilder("li");
                if(i==pagingInfo.CurentPage)
                {
                    tagLi.AddCssClass("page-item active");
                }
                else
                {
                    tagLi.AddCssClass("page-item");
                }

                
                tagLi.InnerHtml = tagA.ToString();

                sb.Append(tagLi.ToString());
            }

            TagBuilder tagUl = new TagBuilder("ul");
            tagUl.InnerHtml = sb.ToString();
            tagUl.AddCssClass("pagination");

            TagBuilder tagNav = new TagBuilder("nav");
            tagNav.InnerHtml = tagUl.ToString();


            return MvcHtmlString.Create(tagNav.ToString());
        }
    }
}