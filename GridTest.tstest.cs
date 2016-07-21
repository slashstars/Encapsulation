using Telerik.WebAii.Controls.Xaml;
using Telerik.WebAii.Controls.Html;
using Telerik.TestingFramework.Controls.KendoUI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using ArtOfTest.Common.UnitTesting;
using ArtOfTest.WebAii.Core;
using ArtOfTest.WebAii.Controls.HtmlControls;
using ArtOfTest.WebAii.Controls.HtmlControls.HtmlAsserts;
using ArtOfTest.WebAii.Design;
using ArtOfTest.WebAii.Design.Execution;
using ArtOfTest.WebAii.ObjectModel;
using ArtOfTest.WebAii.Silverlight;
using ArtOfTest.WebAii.Silverlight.UI;
using EncapFromScratch.Lib;

namespace EncapFromScratch
{

    public class GridTest : BaseWebAiiTest
    {
        #region [ Dynamic Pages Reference ]

        private Pages _pages;

        /// <summary>
        /// Gets the Pages object that has references
        /// to all the elements, frames or regions
        /// in this project.
        /// </summary>
		public Pages Pages
        {
            get
            {
                if (_pages == null)
                {
                    _pages = new Pages(Manager.Current);
                }
                return _pages;
            }
        }

        [CodedStep(@"New Coded Step")]
        public void GridTest_CodedStep()
        {
            TestContext.Set(Manager);
            ActiveBrowser.NavigateTo("http://localhost:3000/projects");
            var grid = new Lib.Grid();

            grid.SelectRow(1);
            System.Threading.Thread.Sleep(5000);

            ActiveBrowser.NavigateTo("http://localhost:3000/projects");

            foreach(string h in grid.GetHeaders())
            {
                Log.WriteLine(h);
            }

            System.Threading.Thread.Sleep(5000);
        }

        #endregion

        // Add your test methods here...
    }
}
