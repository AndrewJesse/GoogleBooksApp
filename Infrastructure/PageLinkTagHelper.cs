using GoogleBooksApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace SportsStore.Infrastructure
{
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PageLinkTagHelper : TagHelper
    {
        public string? SearchString { get; set; }
        public string? Subject { get; set; }

        private IUrlHelperFactory urlHelperFactory;
        public PageLinkTagHelper(IUrlHelperFactory helperFactory)
        {
            urlHelperFactory = helperFactory;
        }
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext? ViewContext { get; set; }
        public PagingInfo? PageModel { get; set; }
        public string? PageAction { get; set; }
        public int MaxPagesToShow { get; set; } = 10;
        public string PreviousPageText { get; set; } = "&lt;";
        public string NextPageText { get; set; } = "&gt;";
        public bool PageClassesEnabled { get; set; } = false;
        public string PageClass { get; set; } = string.Empty;
        public string PageClassNormal { get; set; } = string.Empty;
        public string PageClassSelected { get; set; } = string.Empty;

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (ViewContext != null && PageModel != null)
            {
                IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
                TagBuilder result = new TagBuilder("div");

                int startPage = Math.Max(1, PageModel.CurrentPage - MaxPagesToShow / 2);
                int endPage = Math.Min(PageModel.TotalPages, startPage + MaxPagesToShow - 1);

                if (PageModel.CurrentPage != 1)
                {
                    TagBuilder tag = new TagBuilder("a");
                    tag.Attributes["href"] = urlHelper.Action(PageAction, new { searchString = SearchString, subject = Subject, productPage = PageModel.CurrentPage - 1 });
                    tag.InnerHtml.AppendHtml(PreviousPageText);
                    tag.AddCssClass("btn"); // Add common class
                    tag.AddCssClass(PageClassNormal); // Add normal class
                    result.InnerHtml.AppendHtml(tag);
                }

                for (int i = startPage; i <= endPage; i++)
                {
                    TagBuilder tag = new TagBuilder("a");
                    tag.Attributes["href"] = urlHelper.Action(PageAction, new { searchString = SearchString, subject = Subject, productPage = i });

                    // Add this block to apply styling
                    if (PageClassesEnabled)
                    {
                        tag.AddCssClass(PageClass);
                        tag.AddCssClass(i == PageModel.CurrentPage ? PageClassSelected : PageClassNormal);
                    }

                    tag.InnerHtml.Append(i.ToString());
                    result.InnerHtml.AppendHtml(tag);
                }

                if (PageModel.CurrentPage != PageModel.TotalPages)
                {
                    TagBuilder tag = new TagBuilder("a");
                    tag.Attributes["href"] = urlHelper.Action(PageAction, new { searchString = SearchString, subject = Subject, productPage = PageModel.CurrentPage + 1 });
                    tag.InnerHtml.AppendHtml(NextPageText);
                    tag.AddCssClass("btn"); // Add common class
                    tag.AddCssClass(PageClassNormal); // Add normal class
                    result.InnerHtml.AppendHtml(tag);
                }
                output.Content.AppendHtml(result.InnerHtml);
            }
        }
    }
}
