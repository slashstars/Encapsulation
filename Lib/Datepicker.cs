using ArtOfTest.Common.UnitTesting;
using ArtOfTest.WebAii.Controls.HtmlControls;
using ArtOfTest.WebAii.ObjectModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncapFromScratch.Lib
{

    class Datepicker : BaseUIElement
    {
        string datepickerTableSelector = "id=ui-datepicker-div";
        string nextMonthArrowSelector = "TextContent=Next";
        string previousMonthArrowSelector = "TextContent=Prev";
        string currentMonthSelector = "class=ui-datepicker-month";

        public Datepicker(String selector)
        {
            Selector = selector;
        }

        public HtmlControl DatePickerTable
        {
            get { return ActiveBrowser.Find.ByExpression<HtmlControl>(datepickerTableSelector); }
        }

        public HtmlControl NextMonthArrow
        {
            get
            {
                return DatePickerTable.Find.ByExpression<HtmlControl>(nextMonthArrowSelector);
            }
        }

        public HtmlControl PreviousMonthArrow
        {
            get
            {
                return DatePickerTable.Find.ByExpression<HtmlControl>(previousMonthArrowSelector);
            }
        }

        public Element CurrentMonth
        {
            get
            {
                return ActiveBrowser.Find.ByExpression(currentMonthSelector);
            }
        }

        public void Open()
        {
            var script = "$(\"#{0}\").datepicker(\"show\")";
            ActiveBrowser.Actions.InvokeScript(String.Format(script, Scope.ID));
            Assert.IsTrue(DatePickerTable.IsVisible());
        }

        public void SetMonth(String month)
        {
            SetToFirstMonth();

            while (GetCurrentMonth() != month)
                NextMonthArrow.Click();
        }

        public void SetDay(string date)
        {
            var clickableDateElement = DatePickerTable.Find.ByExpression<HtmlControl>("TextContent=" + date);
            clickableDateElement.Click();
            System.Threading.Thread.Sleep(750);
            Assert.IsFalse(DatePickerTable.IsVisible());

            var expectedDate = buildExpectedDate(GetCurrentMonth(), date);
            Assert.AreEqual<String>(GetSetDate(), expectedDate);

        }

        public String GetSetDate()
        {
            return ActiveBrowser.Find.ByExpression<HtmlInputText>(Selector).Value;
        }

        private void SetToFirstMonth()
        {

            while (GetCurrentMonth() != "January")
                PreviousMonthArrow.Click();
        }

        private String GetCurrentMonth()
        {
            return CurrentMonth.TextContent;
        }

        private string buildExpectedDate(string month, string day)
        {
            string[] monthNames = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.MonthNames;


            var year = DateTime.Now.Year.ToString();
            var monthAsNum = (monthNames.ToList<String>().IndexOf(month) + 1).ToString();
            if (monthAsNum.Length < 2)
                monthAsNum = "0" + monthAsNum;

            if (day.Length < 2)
                day = "0" + day;

            return monthAsNum + "/" + day + "/" + year;
        }

    }

}
