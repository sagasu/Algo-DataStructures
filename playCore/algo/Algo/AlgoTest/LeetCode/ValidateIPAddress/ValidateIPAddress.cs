using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.ValidateIPAddress
{
    [TestClass]
    public class ValidateIPAddressProblem
    {
        [TestMethod]
        public void Test() {
            Assert.AreEqual(ipv6, ValidIPAddress("2001:0db8:85a3:0000:0000:8a2e:0370:7334"));
            Assert.AreEqual(ipv4, ValidIPAddress("172.16.254.1"));
            Assert.AreEqual(neither, ValidIPAddress("172.16.254.01"));
            Assert.AreEqual(neither, ValidIPAddress("02001:0db8:85a3:0000:0000:8a2e:0370:7334"));
            Assert.AreEqual(neither, ValidIPAddress("2001:0db8:85a3::8A2E:0370:7334"));
            Assert.AreEqual(neither, ValidIPAddress("0.0.0.-0"));
            Assert.AreEqual(ipv6, ValidIPAddress("2001:db8:85a3:0:0:8A2E:0370:7334"));
        }

        private string neither = "Neither";
        private string ipv4 = "IPv4";
        private string ipv6 = "IPv6";
        public string ValidIPAddress(string IP)
        {
            if (string.IsNullOrEmpty(IP))
                return neither;

            if (IP.Contains("."))
            {
                var v4 = IP.Split(".");
                if (v4.Length != 4)
                    return neither;

                for (var i = 0; i < v4.Length; i++) {
                    int pars;
                    if (!int.TryParse(v4[i], out pars))
                        return neither;

                    if (pars < 0 || pars > 255 || (v4[i][0] == '0' && v4[i].Length > 1) || v4[i].Contains("-0"))
                        return neither;
                }
                return ipv4;
            }else if (IP.Contains(":"))
            {
                var v6 = IP.Split(":");
                if (v6.Length != 8)
                    return neither;

                for (var i = 0; i < 8; i++) {
                    if (!IsHexString(v6[i]))
                        return neither;

                    if (v6[i].Length > 4)
                        return neither;
                }
                return ipv6;
            }



            return neither;
        }

        private bool IsHexString(string test)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(test, @"\A\b[0-9a-fA-F]+\b\Z");
        }
    }
}
