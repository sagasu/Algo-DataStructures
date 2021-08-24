using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Complex_Number_Multiplication
{
    [TestClass]
    public class Complex_Number_Multiplication
    {
        
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual("0+2i", ComplexNumberMultiply("1+1i", "1+1i"));
        }
        
        [TestMethod]
        public void Test2()
        {
            Assert.AreEqual("0+-2i", ComplexNumberMultiply("1+-1i", "1+-1i"));
        }
        
        
        [TestMethod]
        public void Test3()
        {
            Assert.AreEqual("0+0i", ComplexNumberMultiply("1+-1i", "0+0i"));
        }



        //(a+bi)(c+di) = ac + adi + bci + bdi2
        //i2 = -1 so the result of bdi2 is not imaginary it is -bd
        public string ComplexNumberMultiply(string num1, string num2)
        {
            var nums = num1.Split('+');
            var n1 = int.Parse(nums[0]);
            var n2 = int.Parse(nums[1].Trim('i'));

            nums = num2.Split('+');
            var n3 = int.Parse(nums[0]);
            var n4 = int.Parse(nums[1].Trim('i'));

            var sum = n1 * n3 - n2 * n4;
            var imaginarySum = n1 * n4 + n2 * n3;
            return $"{sum}+{imaginarySum}i";
        }
    }
}
