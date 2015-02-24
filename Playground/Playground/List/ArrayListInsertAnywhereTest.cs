using System.Linq;
using NUnit.Framework;

namespace Playground.List
{
    [TestFixture]
    public class ArrayListInsertAnywhereTest
    {
        [Test]
        public void Add_SingleElement_AbleToRetriveIt()
        {
            var al = new ArrayListInsertAnywhere<int>(){{3,0}};
            
            Assert.AreEqual(1,al.Count());
            Assert.AreEqual(3,al.First());
        }
    }
}
