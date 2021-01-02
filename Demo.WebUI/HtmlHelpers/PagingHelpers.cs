//using Demo.WebUI.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Web;
//using System.Web.Mvc;

//namespace Demo.WebUI.HtmlHelpers
//{
//    public static class PagingHelpers
//    {
//        public static MvcHtmlString PageLinks (this HtmlHelper html, PagingInfo pagingInfo, Func<int, string> pageUrl)
//        {
//            StringBuilder result = new StringBuilder();
//            for(int i=1;i<pagingInfo.TotalPages;++i)
//            {
//                TagBuilder tag = new TagBuilder("a"); //tao the a
//                tag.MergeAttribute("href", pageUrl(i));
//                tag.InnerHtml = i.ToString();
//                TagBuilder tagLi = new TagBuilder("li");
//                if (i == pagingInfo.CurentPage)
//                    tagLi.AddCssClass("active");

//                tagLi.InnerHtml = tag.ToString();
//                result.Append(tagLi.ToString());
//            }    
//            return MvcHtmlString.Create(result.ToString());
//        }
//    }
//}