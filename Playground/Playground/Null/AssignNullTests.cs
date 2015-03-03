using NUnit.Framework;

namespace Playground.Null
{
    [TestFixture]
    class AssignNullTests
    {
        [Test]
        public void TestNullAsignementInMethod()
        {
            var c = new Cut();
            Assert.NotNull(c);

            c = new Cut().AssignNullAndReturn(c);
            Assert.Null(c);

            c = new Cut();
            c.AssignNull(c);
            Assert.NotNull(c);

            var _ = new Cut();
            c = new Cut();

            c.AssignNull(_);
            Assert.NotNull(c);
            Assert.NotNull(_);
        }
    }
}
