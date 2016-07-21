using ArtOfTest.WebAii.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncapFromScratch.Lib
{
    class BaseAutomation
    {

        protected Browser ActiveBrowser
        {
            get
            {
                return TestContext.ActiveBrowser;
            }
        }
    }
}
