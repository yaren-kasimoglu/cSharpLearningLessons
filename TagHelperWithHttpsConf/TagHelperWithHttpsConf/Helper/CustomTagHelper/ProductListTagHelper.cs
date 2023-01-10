using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;

namespace TagHelperWithHttpsConf.Helper.CustomTagHelper
{
    [HtmlTargetElement(tag: "product-list")] //hangi element değiştirilecek ise onu ekliyoruz
    public class ProductListTagHelper : TagHelper
    {
        [HtmlAttributeName("productData")]//html de ki attribute karşılığı
        public string? productData { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output) //context i sayfa gibi düşün. her şeye erişebilirz
        {
            output.TagName = "div"; //değiştirilecek olan element
            //output.PreContent.SetHtmlContent("<ul><li>Yaren</li></ul>");

            string[] productItems = productData.Split(',');
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("<ul>");
            foreach (var item in productItems)
            {
                stringBuilder.AppendFormat("<li>{0}</li>", item);
            }
            stringBuilder.Append("<ul>");

            output.PreContent.SetHtmlContent(stringBuilder.ToString());
            //output.PreContent.SetHtmlContent("<ul><li>Yaren</li></ul>");

        }
    }
}
