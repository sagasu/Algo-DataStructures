using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace playCoreTests
{
    [TestClass]
    public class EventHandlerTest
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
