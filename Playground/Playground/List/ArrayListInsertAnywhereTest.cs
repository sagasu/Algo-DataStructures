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

        [Test]
        public void Add_MultipleElements_AbleToRetriveIt()
        {
            var al = new ArrayListInsertAnywhere<int>() { { 1, 0 }, { 2, 1 }, { 3, 2 }, { 3, 3 } };

            Assert.AreEqual(4, al.Count());
            Assert.AreEqual(1, al.First());
            Assert.AreEqual(2, al.Skip(1).First());
            Assert.AreEqual(3, al.Skip(2).First());
            Assert.AreEqual(3, al.Last());
        }

        [Test]
        public void Add_MultipleElementsMoreThanDefaultSize_AbleToRetriveIt()
        {
            var al = new ArrayListInsertAnywhere<int>() { { 1, 0 }, { 2, 1 }, { 3, 2 }, { 3, 3 }, {4,4},{5,5},{6,6},{7,7},{8,8},{9,9},{10,10},{11,11},{12,12},{13,13},{14,14} };

            Assert.AreEqual(15, al.Count());
            Assert.AreEqual(1, al.First());
            Assert.AreEqual(2, al.Skip(1).First());
            Assert.AreEqual(3, al.Skip(2).First());
            Assert.AreEqual(3, al.Skip(3).First());
            Assert.AreEqual(4, al.Skip(4).First());
            Assert.AreEqual(5, al.Skip(5).First());
            Assert.AreEqual(6, al.Skip(6).First());
            Assert.AreEqual(7, al.Skip(7).First());
            Assert.AreEqual(8, al.Skip(8).First());
            Assert.AreEqual(9, al.Skip(9).First());
            Assert.AreEqual(10, al.Skip(10).First());
            Assert.AreEqual(11, al.Skip(11).First());
            Assert.AreEqual(12, al.Skip(12).First());
            Assert.AreEqual(13, al.Skip(13).First());
            Assert.AreEqual(14, al.Last());
        }

        [Test]
        public void Add_ElementInThirdSlot_AbleToRetriveIt()
        {
            var al = new ArrayListInsertAnywhere<int>() { { 3, 2 } };

            Assert.AreEqual(3, al.Count());
            Assert.AreEqual(0, al.First());
            Assert.AreEqual(0, al.Skip(1).First());
            Assert.AreEqual(3, al.Last());
        }

        [Test]
        public void Add_ElementInSlotThatRequiresArrayToBeCopied_AbleToRetriveIt()
        {
            var al = new ArrayListInsertAnywhere<int>() { { 3, 5 } };

            Assert.AreEqual(6, al.Count());
            Assert.AreEqual(0, al.First());
            Assert.AreEqual(0, al.Skip(1).First());
            Assert.AreEqual(0, al.Skip(2).First());
            Assert.AreEqual(0, al.Skip(3).First());
            Assert.AreEqual(0, al.Skip(4).First());
            Assert.AreEqual(3, al.Skip(5).First());
            Assert.AreEqual(3, al.Last());
        }

        [Test]
        public void Update_ElementInThirdSlotBeAbleToUpdateIt_AbleToRetriveIt()
        {
            var al = new ArrayListInsertAnywhere<int>() { { 3, 2 } };
            al.Add(8,2);
            Assert.AreEqual(3, al.Count());
            Assert.AreEqual(0, al.First());
            Assert.AreEqual(0, al.Skip(1).First());
            Assert.AreEqual(8, al.Last());
        }
    }
}
