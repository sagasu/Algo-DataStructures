using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

using Playground.ServiceReference1;

namespace Playground
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void SoapClientTest()
        {
            var client = new InternalServiceClient();

            Console.WriteLine("IV " + BrandEnum.IV.ToString());
            var iv = client.LoadBrochureLookupList(BrandEnum.IV);
            Console.WriteLine(iv.Count);
            Console.WriteLine(string.Join("", iv));
            

            var tt = client.LoadBrochureLookupList(BrandEnum.TT);
            Console.WriteLine("TT");
            Console.WriteLine(tt.Count);
            Console.WriteLine(string.Join("", tt));

            Console.WriteLine("Except");

            Console.WriteLine(string.Join("", tt.Except(iv)));
        }
    }

    //internal class DicComparere : IEqualityComparer<KeyValuePair<string, int>>
    //{
    //    public bool Equals(KeyValuePair<string, int> x, KeyValuePair<string, int> y)
    //    {
    //        return x.Key == y.Key && x.Value == y.Value;
    //    }

    //    public int GetHashCode(KeyValuePair<string, int> obj)
    //    {
    //        return obj.Value.GetHashCode() + obj.Key.GetHashCode();
    //    }
    //}
}
