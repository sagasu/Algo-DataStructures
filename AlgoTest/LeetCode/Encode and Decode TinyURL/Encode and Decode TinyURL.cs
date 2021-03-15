using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Encode_and_Decode_TinyURL
{
    [TestClass]
    public class Encode_and_Decode_TinyURL
    {
        [TestMethod]
        public void Test()
        {
            var codec = new Codec();
            var url = "https://leetcode.com/problems/design-tinyurl";
            Assert.AreEqual(url, codec.decode(codec.encode(url)));
        }
    }


    public class Codec
    {

        // Encodes a URL to a shortened URL
        public string encode(string longUrl)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(longUrl);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        // Decodes a shortened URL to its original URL.
        public string decode(string shortUrl)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(shortUrl);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }

    // Your Codec object will be instantiated and called as such:
    // Codec codec = new Codec();
    // codec.decode(codec.encode(url));
}
