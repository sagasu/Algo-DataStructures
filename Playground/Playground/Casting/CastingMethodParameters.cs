using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Playground.Casting
{
    [TestFixture]
    public class CastingMethodParameters
    {
        [Test]
        public void TestMethodCasT()
        {
            var intList = new List<int>();
            var int32List = new List<Int32>();
            var int16List = new List<Int16>();
            var int64List = new List<Int64>();

            #region method calls below are not legal

            //DoubleParameter(intList);
            //DoubleParameter(int16List);
            //DoubleParameter(int32List);
            //DoubleParameter(int64List);

            //FloatParameter(intList);

            #endregion
        }

        public void DoubleParameter(IList<double> foo)
        {
        }

        public void FloatParameter(IList<float> foo)
        {
        }
    }
}
