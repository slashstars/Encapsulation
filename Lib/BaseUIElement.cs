using ArtOfTest.WebAii.Controls.HtmlControls;
using ArtOfTest.WebAii.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncapFromScratch.Lib
{
    class BaseUIElement : BaseAutomation
    {
        private string selector;
        public string Selector
        {
            get
            {
                return selector;
            }

            protected set { selector = value; }
        }

        protected HtmlControl scope;
        public HtmlControl Scope
        {
            get
            {
                if (String.IsNullOrEmpty(Selector))
                    throw new Exception("Selector not set!");

                var expression = new HtmlFindExpression(selector);
                return ActiveBrowser.WaitForElement(expression, 10000, false).As<HtmlControl>();
            }
        }
    }
}
