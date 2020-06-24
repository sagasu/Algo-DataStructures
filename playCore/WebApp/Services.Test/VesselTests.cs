using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Services.Test
{
    [TestClass]
    public class VesselTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var vessel = new Vessel();

            var v = vessel.GetVessel();

            Assert.IsNotNull(v);
        }
    }
}
