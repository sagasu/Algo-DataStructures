using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.Integer_to_English_Words;

public class Integer_to_English_Words
{
    Dictionary<int, string> dict = new();
    
    public string NumberToWords(int num) {
        
        if(num == 0) return "Zero";
        InitDict();
        var st = new Stack<string>();

        var index = 0;

        while(num > 0) {
            var hundreds = num % 1000;
        
            if(hundreds != 0) {
                if(index == 1) st.Push("Thousand");
                if(index == 2) st.Push("Million");
                if(index == 3) st.Push("Billion");

                var dozens = hundreds % 100;

                if(dozens != 0) {
                    if(dozens < 20) {
                        st.Push(dict[dozens]);
                    }
                    else {
                        var digits = dozens % 10;
                        if(digits != 0) {
                            st.Push(dict[digits]);
                            st.Push(dict[(dozens / 10) * 10]);
                        }
                        else {
                            st.Push(dict[dozens]);
                        }                    
                    }
                }

                if(hundreds / 100 > 0) {
                    st.Push("Hundred");
                    st.Push(dict[hundreds / 100]);
                }

            }
            
            index++;
            num /= 1000;

        }
        
 
        var builder = new StringBuilder();
        while(st.Count > 0) builder.Append(st.Pop() + " ");
        builder.Remove(builder.Length - 1, 1);
        return builder.ToString();
    }

    private void InitDict() {
        dict.Add(1, "One");
        dict.Add(2, "Two");
        dict.Add(3, "Three");
        dict.Add(4, "Four");
        dict.Add(5, "Five");
        dict.Add(6, "Six");
        dict.Add(7, "Seven");
        dict.Add(8, "Eight");
        dict.Add(9, "Nine");
        dict.Add(10, "Ten");
        dict.Add(11, "Eleven");
        dict.Add(12, "Twelve");
        dict.Add(13, "Thirteen");
        dict.Add(14, "Fourteen");
        dict.Add(15, "Fifteen");
        dict.Add(16, "Sixteen");
        dict.Add(17, "Seventeen");
        dict.Add(18, "Eighteen");
        dict.Add(19, "Nineteen");
        dict.Add(20, "Twenty");
        dict.Add(30, "Thirty");
        dict.Add(40, "Forty");
        dict.Add(50, "Fifty");
        dict.Add(60, "Sixty");
        dict.Add(70, "Seventy");
        dict.Add(80, "Eighty");
        dict.Add(90, "Ninety");
    }
}