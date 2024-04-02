using System.Collections.Generic;

namespace AlgoTest.LeetCode.Employee_Importance;

public class Employee_Importance
{
    private int res;
    private Dictionary<int, int> importance = new();
    private Dictionary<int, List<int>> relationship = new();
    private HashSet<int> visited = new();
    
    public int GetImportance(IList<Employee> employees, int id) {
        if (employees == null || employees.Count == 0)
            return 0;
        
        foreach (var emp in employees)
        {
            if (!importance.ContainsKey(emp.id))
                importance.Add(emp.id, emp.importance);
            
            if (!relationship.ContainsKey(emp.id))
                relationship.Add(emp.id, new List<int>(emp.subordinates));
        }
        
        visited.Add(id);
        DFS(id);
        
        return res;
    }
    
    private void DFS(int cur)
    {
        res += importance[cur];
        
        foreach (var sub in relationship[cur])
            if (!visited.Contains(sub))
            {
                visited.Add(sub);
                DFS(sub);
            }
    }


    public class Employee {
        public int id;
        public int importance;
        public IList<int> subordinates;
    }
}