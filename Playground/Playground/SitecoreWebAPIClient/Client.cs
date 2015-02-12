using System.Collections.Specialized;
using System.Net;
using NUnit.Framework;

namespace Playground.SitecoreWebAPIClient
{
    [TestFixture]
    public class Client
    {
        [Test]
        public void ReceiveResponse_ValidSecurity_Success()
        {
            var client = new WebClient();

            var n = new NameValueCollection();
            n["X-Scitemwebapi-Username"] = @"extranet\webapi";
            n["X-Scitemwebapi-Password"] = "standardMas";

            client.Headers.Add(n);

            var result = client.DownloadString(
                      "http://my.trafalgar.com/-/item/v1/?sc_itemid={AB881E56-C187-47DF-BCF6-395DD545D95E}");

        }
    }
}
