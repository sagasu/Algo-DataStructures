using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace playCoreTests
{
    [TestClass]
    class EventHandlerTest
    {
        public event EventHandler Clicked;

        [TestMethod]
        public void TestNullability()
        {
            // nice way to check if event is not null
            Clicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
