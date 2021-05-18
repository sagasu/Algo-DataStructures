using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgoTest.LeetCode.Find_Duplicate_File_in_System
{
    [TestClass]
    public class Find_Duplicate_File_in_System
    {
        [TestMethod]
        public void Test()
        {
            var t = new string[]
                {"root/a 1.txt(abcd) 2.txt(efgh)", "root/c 3.txt(abcd)", "root/c/d 4.txt(efgh)", "root 4.txt(efgh)"};
            IList<IList<string>> r = new List<IList<string>>
            {
                new List<string> {"root/a/2.txt", "root/c/d/4.txt", "root/4.txt"},
                new List<string> {"root/a/1.txt", "root/c/3.txt"},
            };
            FindDuplicate(t);
        }
        
        
        [TestMethod]
        public void Test2()
        {
            var t = new string[]
                {"root/a 1.txt(abcd) 2.txt(efsfgh)","root/c 3.txt(abdfcd)","root/c/d 4.txt(efggdfh)"};
            IList<IList<string>> r = new List<IList<string>>{};
            FindDuplicate(t);
        }

        public IList<IList<string>> FindDuplicate(string[] paths)
        {
            var dic = new Dictionary<string, List<string>>();
            foreach (var path in paths)
            {
                var files = path.Split(' ');
                var root = files[0];

                for (var i = 1; i < files.Length; i++)
                {
                    var endOfFileName = files[i].LastIndexOf('(');
                    var fileName = root + "/" + files[i].Substring(0, endOfFileName);
                    var content = files[i].Substring(endOfFileName+1, files[i].Length-1- endOfFileName);
                    if (!dic.TryAdd(content, new List<string> {fileName})) dic[content].Add(fileName);
                }
            }

            var ret = new List<IList<string>>();
            foreach (var dicKey in dic.Keys)
            {
                if(dic[dicKey].Count > 1) ret.Add(dic[dicKey]);
            }

            return ret;
        }
    }
}
