using System.Collections.Generic;
using System.Text;

namespace AlgoTest.LeetCode.Repeated_DNA_Sequences;

public class Repeated_DNA_Sequences
{
    public IList<string> FindRepeatedDnaSequences(string s) {
        List<string> result = new ();
        Dictionary<string,int> map = new();
        int n=s.Length;
        int i=0;
        int j=0;
        StringBuilder sb = new ();
        while(j<n)
        {
            sb.Append(s[j]);
            if(j-i+1==10)
            {
                string key=sb.ToString();
                if(!map.ContainsKey(key))
                    map[key]=0;
                map[key]++;
                sb.Remove(0,1);
                i++;
            }
            j++;
        }
        foreach(KeyValuePair<string,int> kvp in map)
        {
            if(kvp.Value >=2)
                result.Add(kvp.Key);
        }
        return result;
    }
}