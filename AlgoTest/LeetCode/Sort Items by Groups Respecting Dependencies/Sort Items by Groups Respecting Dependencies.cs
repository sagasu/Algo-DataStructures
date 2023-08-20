using System.Collections.Generic;

namespace AlgoTest.LeetCode.Sort_Items_by_Groups_Respecting_Dependencies;

public class Sort_Items_by_Groups_Respecting_Dependencies
{
    public int[] SortItems(int n, int m, int[] group, IList<IList<int>> beforeItems) {
              
        int[] groupInDegree;
        Dictionary<int, HashSet<int>>[] groupNumLinks;        
        InitializeGroups(ref m, group, out groupInDegree, out groupNumLinks);
            
        int[] numInDegree = new int[n];         
        HashSet<int>[] groupLinks = new HashSet<int>[m];
         
        BuildLinks(beforeItems, group, groupLinks, groupNumLinks, groupInDegree, numInDegree);
        
        int[] groupOrder = OrderGroup(groupInDegree, groupLinks);
         
        if (groupOrder == null) { return new int[0]; }
        
        int[] result = new int[n];
        int start = 0;
        
        foreach(int g1 in groupOrder)
        {
            OrderNums(result, ref start, numInDegree, groupNumLinks[g1]);
        }
        
        return (start < n)? new int[0]: result;
    }
    
    private void InitializeGroups(ref int m, int[] group, out int[] groupInDegree, out Dictionary<int, HashSet<int>>[] groupNumLinks)
    {
         // so all non groups are distinct.
        for(int i=0; i< group.Length; i++)
        {
            if (group[i] == -1) { group[i] = m; m++; }
        }
        
        groupInDegree = new int[m];
        groupNumLinks = new Dictionary<int, HashSet<int>>[m];
           
        for(int i=0; i< m; i++)
        {
            groupNumLinks[i] = new Dictionary<int, HashSet<int>>(); 
        }
        
        for(int i=0; i< group.Length; i++)
        {  
            groupNumLinks[group[i]][i] = new HashSet<int>(); 
        }
    }
    
    private void OrderNums(int[] result, ref int start, int[] inDegree, Dictionary<int, HashSet<int>> outLinks)
    {  
        Queue<int> queue = new Queue<int>();
        
        foreach(int i in outLinks.Keys)
        {
            if (inDegree[i] == 0) { queue.Enqueue(i); }
        }
        
        int crnt;
         
        while(queue.Count > 0)
        {
            crnt = queue.Dequeue();
            
            result[start] = crnt;
            start++;
            
            foreach(int n1 in outLinks[crnt])
            {
                inDegree[n1]--;
                if (inDegree[n1] == 0) { queue.Enqueue(n1); }
            }
        }
    }
    
    
    private int[] OrderGroup(int[] inDegree, HashSet<int>[] outLinks)
    {
        int[] result = new int[outLinks.Length];
        
        Queue<int> queue = new Queue<int>();
        
        for(int i=0; i< inDegree.Length; i++)
        {
            if (inDegree[i] == 0) { queue.Enqueue(i); }
        }
        
        int crnt;
        int pos = 0;
        
        while(queue.Count > 0)
        {
            crnt = queue.Dequeue();
            
            result[pos] = crnt;
            pos++;
            
            if (outLinks[crnt] != null)
            {
                foreach(int g1 in outLinks[crnt])
                {
                    inDegree[g1]--;
                    if (inDegree[g1] == 0) { queue.Enqueue(g1); }
                }
            }
        }
        
        return  (pos != result.Length)? null: result; 
    }
    
    
    private void BuildLinks(IList<IList<int>> beforeItems, 
                            int[] group, HashSet<int>[] groupLinks, 
                            Dictionary<int, HashSet<int>>[] groupNumLinks, 
                            int[] groupInDegree, 
                            int[] numInDegree)
    {
        int g1;
        int g2;
        
        for(int i = 0; i< beforeItems.Count; i++)
        {
            g1 = group[i];
            
            foreach(int num in beforeItems[i])
            {
                g2 = group[num];
                
                if (g1 == g2)
                {                    
                   if (groupNumLinks[g2][num].Add(i)) { numInDegree[i]++; }
                }
                else
                {
                   if (groupLinks[g2] == null)
                   {
                       groupLinks[g2] = new HashSet<int>();
                   }                    
                   if (groupLinks[g2].Add(g1)) { groupInDegree[g1]++; }
                }
            }
        }
    }
}