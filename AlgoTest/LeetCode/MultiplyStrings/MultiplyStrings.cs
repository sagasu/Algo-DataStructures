using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.MultiplyStrings
{
    [TestClass]
    public class MultiplyStrings
    {
        [TestMethod]
        public void Test()
        {
            Multiply("123", "456");
        }

        public string Multiply(string num1, string num2)
        {
            if (num1.Length == 1 && int.Parse(num1) == 0)
                return "0";

            if (num2.Length == 1 && int.Parse(num2) == 0)
                return "0";

            var result = new string[num1.Length];
            var carry = 0;
            var zeroCount = 0;
            for (var i = num1.Length-1; i >= 0; i--)
            {
                result[i] = "";
                var currentZeroCount = zeroCount;
                while (currentZeroCount > 0)
                {
                    currentZeroCount -= 1;
                    result[i] += "0";
                }

                zeroCount += 1;
                var n1 = int.Parse(num1[i].ToString());

                for (var j = num2.Length-1; j >= 0; j--)
                {
                    var n2 = int.Parse(num2[j].ToString());

                    var sum = n1 * n2 + carry;

                    if (sum > 10)
                    {
                        result[i] += sum % 10;
                        carry = sum / 10;
                    }
                    else
                    {
                        if (sum == 10)
                        {
                            result[i] += "0";
                            carry = 1;
                        }
                        else
                        {
                            result[i] += sum;
                            carry = 0;
                        }

                        
                    }
                }

                result[i] += carry == 0 ? "" : carry.ToString();
                carry = 0;
            }

            var index = result.Length - 1;
            for (var i = result.Length - 2; i >= 0; i--)
            {
                var newBase = "";
                var maxStringLength = Math.Max(result[index].Length, result[i].Length);
                for (var j = 0; j < maxStringLength; j++)
                {
                    var n1 = result[index].Length > j ? int.Parse(result[index][j].ToString()) : 0;
                    var n2 = result[i].Length > j ? int.Parse(result[i][j].ToString()) : 0;
                        var sum = n1 + n2 + carry;
                        if (sum > 10)
                        {
                            newBase += sum % 10;
                            carry = sum / 10;
                        }
                        else
                        {
                            if (sum == 10)
                            {
                                newBase += "0";
                                carry = 1;
                            }
                            else
                            {
                                newBase += sum;
                                carry = 0;
                        }
                            
                            
                        }

                }

                result[index] = carry == 0? newBase: newBase + carry.ToString();
                carry = 0;
            }

            var sb = new StringBuilder();
            for (int i = result[index].Length - 1; i >= 0; i--)
            {
                sb.Append(result[index][i]);
            }

            return sb.ToString();
        }

        
    }
}

