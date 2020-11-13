using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.GoatLatin
{
    [TestClass]
    public class GoatLatin
    {
        [TestMethod]
        public void Test()
        {
            Assert.AreEqual("Imaa peaksmaaa oatGmaaaa atinLmaaaaa", ToGoatLatin("I speak Goat Latin"));
            Assert.AreEqual("heTmaa uickqmaaa rownbmaaaa oxfmaaaaa umpedjmaaaaaa overmaaaaaaa hetmaaaaaaaa azylmaaaaaaaaa ogdmaaaaaaaaaa", ToGoatLatin("The quick brown fox jumped over the lazy dog"));
        }

        public string ToGoatLatin(string S)
        {
            if (string.IsNullOrEmpty(S))
                return S;

            var goatPrefix = "ma";
            var vovels = new[] {'a', 'i', 'u', 'e', 'o'};
            var goatSentence = new List<char>();
            var sentenceIndex = 0;
            var lastChar = ' ';
            var addLastChar = false;

            var words = S.Split(" ");
            for (var j = 0; j < words.Length; j++)
            {
                for (var i = 0; i < words[j].Length;i++)
                {
                    var character = words[j][i];

                    if (i == 0)
                    {
                        sentenceIndex += 1;
                        if (vovels.Any(v => char.ToLower(character) == v))
                        {
                            goatSentence.Add(character);

                        }
                        else
                        {
                            addLastChar = true;
                            lastChar = character;
                        }
                    }
                    else
                    {
                        goatSentence.Add(character);
                    }
                }

                if (addLastChar)
                {
                    goatSentence.Add(lastChar);
                }

                goatSentence.AddRange(goatPrefix + new string('a', sentenceIndex));
                addLastChar = false;
                if(j != words.Length - 1)
                    goatSentence.Add(' ');
            }
            
            return new string(goatSentence.ToArray());
        }
    }
}
