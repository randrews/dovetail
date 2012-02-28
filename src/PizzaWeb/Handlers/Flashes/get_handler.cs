using FubuMVC.Core;
using FubuMVC.Core.SessionState;
using HtmlTags;
using System.Collections.Generic;

namespace PizzaWeb.Handlers.Flashes
{
    public class get_handler
    {
        private readonly IFlash _flash;

        public get_handler(IFlash flash)
        {
            _flash = flash;
        }

        [FubuPartial]
        public string Execute(GetFlashes input)
        {
            /*
                <div class="alert">
                  <a class="close" data-dismiss="alert">×</a>
                  <strong>Warning!</strong> Best check yo self, you're not looking too good.
                </div>
             */

            var array = _flash.Retrieve<string[]>();
            if (array == null) return new NoTag().ToHtmlString();

            var div = new HtmlTag("div").AddClass("alert");
            var closeLink = new HtmlTag("a").AddClass("close").Data("dismiss", "alert");
            div.Append(closeLink);
            
            var ul = new HtmlTag("ul");

            array.Each(i => ul.Append("li", l => l.Text(i)));

            div.Append(ul);
            return div.ToHtmlString();
        }
    }

    public class GetFlashes{}
}