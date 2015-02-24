using System.Linq;
using NUnit.Framework;

namespace Playground.List
{
    [TestFixture]
    public class SimpleLinkedListTests
    {
        [Test]
        public void Add_SingleElementToList_ShouldBeAbleToRetriveIt()
        {
            var sll = new SimpleLinkedList<bool> {true};

            Assert.AreEqual(1, sll.Count());
            Assert.AreEqual(true, sll.First());
        }

        [Test]
        public void Add_ThreeElementsToList_ShouldBeAbleToRetriveIt()
        {
            var sll = new SimpleLinkedList<bool> {true, true, false};

            Assert.AreEqual(3, sll.Count());
            Assert.AreEqual(true, sll.First());
            Assert.AreEqual(true, sll.Skip(1).First());
            Assert.AreEqual(false, sll.Last());
        }

        [Test]
        public void Add_ElementByIndex_ShouldBeAbleToRetriveIt()
        {
            var sll = new SimpleLinkedList<bool> {true, true, true, {false, 1}};

            Assert.AreEqual(4, sll.Count());
            Assert.AreEqual(true, sll.First());
            Assert.AreEqual(false, sll.Skip(1).First());
            Assert.AreEqual(true, sll.Skip(2).First());
            Assert.AreEqual(true, sll.Last());
        }

        [Test]
        public void Add_ElementByIndexZero_ShouldBeAbleToRetriveIt()
        {
            var sll = new SimpleLinkedList<bool> { { true, 0 } };

            Assert.AreEqual(1, sll.Count());
            Assert.AreEqual(true, sll.First());
        }

        [Test]
        public void Remove_SingleElement_ShouldWork()
        {
            var sll = new SimpleLinkedList<bool> { true };
            sll.Remove(0);

            Assert.AreEqual(0, sll.Count());
        }

        [Test]
        public void Remove_SecondElement_ShouldWork()
        {
            var sll = new SimpleLinkedList<bool> { true, false, true, true, true };
            sll.Remove(1);

            Assert.AreEqual(4, sll.Count());
            Assert.AreEqual(true, sll.First());
            Assert.AreEqual(true, sll.Skip(1).First());
            Assert.AreEqual(true, sll.Skip(2).First());
            Assert.AreEqual(true, sll.Last());
        }

        [Test]
        public void TestHeadAssignmenet_RemoveSecondElementAndAddToSecondPosition_ElementShouldBeAssignedToSecondPosition()
        {
            var sll = new SimpleLinkedList<int> { 1, 2, 3, 4, 5 };
            sll.Remove(1);
            sll.Add(6, 1);

            Assert.AreEqual(5, sll.Count());
            Assert.AreEqual(1, sll.First());
            Assert.AreEqual(6, sll.Skip(1).First());
            Assert.AreEqual(3, sll.Skip(2).First());
            Assert.AreEqual(4, sll.Skip(3).First());
            Assert.AreEqual(5, sll.Last());
        }

        [Test]
        public void TestHeadAssignmenet_RemoveFourthElementAndAddToSecondPosition_ElementShouldBeAssignedToSecondPosition()
        {
            var sll = new SimpleLinkedList<int> { 1, 2, 3, 4, 5 };
            sll.Remove(3);
            sll.Add(6, 1);

            Assert.AreEqual(5, sll.Count());
            Assert.AreEqual(1, sll.First());
            Assert.AreEqual(6, sll.Skip(1).First());
            Assert.AreEqual(2, sll.Skip(2).First());
            Assert.AreEqual(3, sll.Skip(3).First());
            Assert.AreEqual(5, sll.Skip(4).First());
            Assert.AreEqual(5, sll.Last());
        }

        [Test]
        public void TestHeadAssignmenet_RemoveLastElementAndAddToSecondPosition_ElementShouldBeAssignedToSecondPosition()
        {
            var sll = new SimpleLinkedList<int> { 1, 2, 3, 4, 5 };
            sll.Remove(4);
            sll.Add(6, 1);

            Assert.AreEqual(5, sll.Count());
            Assert.AreEqual(1, sll.First());
            Assert.AreEqual(6, sll.Skip(1).First());
            Assert.AreEqual(2, sll.Skip(2).First());
            Assert.AreEqual(3, sll.Skip(3).First());
            Assert.AreEqual(4, sll.Skip(4).First());
            Assert.AreEqual(4, sll.Last());
        }

        [Test]
        public void TestHeadAssignmenet_RemoveFirstElementAndAddToSecondPosition_ElementShouldBeAssignedToSecondPosition()
        {
            var sll = new SimpleLinkedList<int> { 1, 2, 3, 4, 5 };
            sll.Remove(0);
            sll.Add(6, 1);

            Assert.AreEqual(5, sll.Count());
            Assert.AreEqual(2, sll.First());
            Assert.AreEqual(6, sll.Skip(1).First());
            Assert.AreEqual(3, sll.Skip(2).First());
            Assert.AreEqual(4, sll.Skip(3).First());
            Assert.AreEqual(5, sll.Skip(4).First());
            Assert.AreEqual(5, sll.Last());
        }

        [Test]
        public void TestHeadAssignmenet_RemoveFirstElementAndAddToFirstPosition_ElementShouldBeAssignedToSecondPosition()
        {
            var sll = new SimpleLinkedList<int> { 1, 2, 3, 4, 5 };
            sll.Remove(0);
            sll.Add(6, 0);

            Assert.AreEqual(5, sll.Count());
            Assert.AreEqual(6, sll.First());
            Assert.AreEqual(2, sll.Skip(1).First());
            Assert.AreEqual(3, sll.Skip(2).First());
            Assert.AreEqual(4, sll.Skip(3).First());
            Assert.AreEqual(5, sll.Skip(4).First());
            Assert.AreEqual(5, sll.Last());
        }
    }
}
