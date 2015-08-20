using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Playground.Inheritance
{
    [TestFixture]
    public class MethodCallsToSubClass
    {
        [Test]
        public void SubClass_CallMethodOnSubClass_ExpectSubclassReturnValue()
        {
            var subClass = new SubClass();
            Assert.AreEqual(2, subClass.Method());
        }

        [Test]
        public void SubClassWithNew_CallMethodOnSubClassWithNew_ExpectSubClassWithNewReturnValue()
        {
            var subClass = new SubClassWithNew();
            Assert.AreEqual(3, subClass.Method());
        }
    }

    public class SuperClass
    {
        public int Method()
        {
            return 1;
        }
    }

    public class SubClass : SuperClass
    {
        public int Method()
        {
            return 2;
        }
    }

    public class SubClassWithNew : SuperClass
    {
        public new int Method()
        {
            return 3;
        }
    }
}
