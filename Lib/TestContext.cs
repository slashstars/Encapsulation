using ArtOfTest.WebAii.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncapFromScratch.Lib
{
    class TestContext
    {
        public static Manager CurrentTestManager;
        public static Browser ActiveBrowser;

        public static void Set(Manager manager)
        {

            CurrentTestManager = manager;
            ActiveBrowser = manager.ActiveBrowser;

        }

    }
}
