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

namespace EncapFromScratch
{

    public class TriggerInputs : BaseWebAiiTest
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
        public void TriggerInputs_CodedStep()
        {
            var script = "$('input').trigger('input');";
            Actions.InvokeScript(script);
        }

        #endregion

        // Add your test methods here...
    }
}
