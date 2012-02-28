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
            var ul = new HtmlTag("ul");

            var array = _flash.Retrieve<string[]>();

            if (array == null) return new NoTag().ToHtmlString();

            array.Each(i => ul.Append("li", l => l.Text(i)));

            return ul.ToHtmlString();
        }
    }

    public class GetFlashes{}
}