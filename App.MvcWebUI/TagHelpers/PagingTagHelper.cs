using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;

namespace App.MvcWebUI.TagHelpers
{
    [HtmlTargetElement("product-list-pager")]
    public class PagingTagHelper : TagHelper
    {
        [HtmlAttributeName("page-size")]
        public int PageSize { get; set; }
        [HtmlAttributeName("page-count")]
        public int PageCount { get; set; }
        [HtmlAttributeName("current-category")]
        public int CurrentCategory { get; set; }
        [HtmlAttributeName("current-page")]
        public int CurrentPage { get; set; }
        [HtmlAttributeName("order")]
        public string Order { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            var sb = new StringBuilder();
            sb.Append("<ul class='pagination' >");
            if (CurrentPage !=  1)
            {
                sb.AppendFormat("<li class='page-item'>");
                sb.AppendFormat("<a class='page-link' href='/product/index?page={0}&category={1}&order={2}'>{3}</a>", (CurrentPage - 1), CurrentCategory, Order, "Previous");
                sb.Append("</li>");
            }
            for (int i = 1; i <= PageCount; i++)
            {
                sb.AppendFormat("<li class='{0}'>", (i == CurrentPage) ? "page-item active" : "page-item");
                sb.AppendFormat("<a class='page-link' href='/product/index?page={0}&category={1}&order={2}'>{3}</a>", i, CurrentCategory, Order, i);
                sb.Append("</li>");
            }

            if (CurrentPage != PageCount)
            {
                sb.AppendFormat("<li class='page-item'>");
                sb.AppendFormat("<a class='page-link' href='/product/index?page={0}&category={1}&order={2}'>{3}</a>", (CurrentPage + 1), CurrentCategory, Order, "Next");
                sb.Append("</li>");
            }

            sb.Append("</ul>");

            output.Content.SetHtmlContent(sb.ToString());
        }
    }
}
