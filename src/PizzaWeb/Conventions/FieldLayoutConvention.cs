using System.Collections.Generic;
using FubuMVC.Core.UI.Forms;
using HtmlTags;

namespace PizzaWeb.Conventions
{
    public class FieldLayoutConvention : ILabelAndFieldLayout
    {
        private HtmlTag _inputHolder;
        private HtmlTag _label;
        private HtmlTag _span;

        public FieldLayoutConvention()
        {
            _inputHolder = new HtmlTag("p");
            _label = new HtmlTag("label");
            _span = new HtmlTag("span");
        }

        public IEnumerable<HtmlTag> AllTags()
        {
            yield return _inputHolder;
        }

        public HtmlTag LabelTag
        {
            get { return _label; }
            set { _label = value; }
        }

        public HtmlTag BodyTag
        {
            get { return _label.FirstChild(); }
            set { _label.ReplaceChildren(value); }
        }

        public override string ToString()
        {
            _span.Text(_label.Text());
            _label.Text("");
            _label.Children.Insert(0, _span);
            _inputHolder.Append(_label);
            return string.Format("{0}\n", _inputHolder);
        }
    }
}