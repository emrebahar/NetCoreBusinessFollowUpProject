using Microsoft.AspNetCore.Razor.TagHelpers;
using Project.Todo.Business.Interfaces;
using Project.Todo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Todo.Web.TagHelpers
{
    [HtmlTargetElement("getirGorevAppUserId")]
    public class GorevAppUserIdTagHelper : TagHelper
    {
        private readonly IGorevService _gorevService;
        public GorevAppUserIdTagHelper(IGorevService gorevService)
        {
            _gorevService = gorevService;
        }
        public int AppUserId { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            List<Gorev> gorevler = _gorevService.GetirileAppUserId(AppUserId);
            int tamamlananGorevSayisi = gorevler.Where(I => I.Durum).Count();
            int ustundeCalistigiGorevSayisi = gorevler.Where(I => !I.Durum).Count();

            string htmlString = $"<strong>Tamaladığı görev sayısı :</strong> {tamamlananGorevSayisi} <br> <strong>Üstünde Çalıştığı görev Sayısı :</strong> {ustundeCalistigiGorevSayisi}";

            output.Content.SetHtmlContent(htmlString);
        }
    }
}
