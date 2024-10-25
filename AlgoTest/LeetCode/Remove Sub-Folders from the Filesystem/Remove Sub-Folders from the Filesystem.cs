using System;
using System.Collections.Generic;

namespace AlgoTest.LeetCode.Remove_Sub_Folders_from_the_Filesystem;

public class Remove_Sub_Folders_from_the_Filesystem
{
    public IList<string> RemoveSubfolders(string[] folder) 
    {
        var set = new HashSet<string>();
        var result = new List<string>();
         
        Array.Sort(folder, string.CompareOrdinal);
          
        foreach(string s in folder)
        {
            string[] file = s.Split('/');
            bool isFound = false;
            string val = "";
            foreach(string f in file)
            {             
                if(string.IsNullOrEmpty(f))
                    continue;
                  
                val += $"/{f}";               
                  
                if(set.Contains(val))
                {
                    isFound = true;
                    break;
                }
            }
              
            if(!isFound)
                set.Add(val);
              
        }
          
        foreach(string s in set)
            result.Add(s);
          
        return result;
        
    }
}