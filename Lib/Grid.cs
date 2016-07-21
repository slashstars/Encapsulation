using ArtOfTest.WebAii.Controls.HtmlControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncapFromScratch.Lib
{
    class Grid : BaseUIElement
    {
        const String defaultSelector = "xpath=//table";
        private String rowSelector = "xpath=//tbody/tr[{0}]";

        public Grid(string selector = defaultSelector)
        {
            Selector = selector;
        }

        public void SelectRow(int index)
        {
            var row = Scope.Find.ByExpression<HtmlControl>(String.Format(rowSelector, index));

            row.Click();
        }

        public String[] GetHeaders()
        {
            var headers = Scope.Find.AllByXPath("//thead//tr[1]//th");

            var headersText = headers.Select(header => header.TextContent).ToArray();

            return headersText;
        }
    }
}
