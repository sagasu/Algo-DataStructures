using System.Collections.Generic;
using System.Linq;

namespace AlgoTest.LeetCode.Build_a_Matrix_With_Conditions;

public class Build_a_Matrix_With_Conditions
{
  public int[][] BuildMatrix(int k, int[][] rowConditions, int[][] colConditions) 
  {
    var res = new int[k][];
    var gRows = new List<int>[k+1];
    var gColumns = new List<int>[k+1];
    
    foreach (var edge in rowConditions)
    {
      gRows[edge[0]] ??= new List<int>();
      gRows[edge[0]].Add(edge[1]);
    }
    
    foreach (var edge in colConditions)
    {
      gColumns[edge[0]] ??= new List<int>();
      gColumns[edge[0]].Add(edge[1]);
    }
    
    var rowStack = new Stack<int>(k+1);
    var columnStack = new Stack<int>(k+1);
    if(!TopologicalSort(gRows, rowStack)) return new int[0][];
    if(!TopologicalSort(gColumns, columnStack)) return new int[0][];
    
    var matrixOrder = new int[k+1][]; 
    var lastRow = BuildMatrixOrder(matrixOrder, rowStack, 0);
    var lastColumn = BuildMatrixOrder(matrixOrder, columnStack, 1);

    for(var i = 1; i <= k; i++)
    {
      var pos = matrixOrder[i];
      var r = pos[0] >= 0 ? pos[0]: lastRow++;
      var c = pos[1] >= 0 ? pos[1]: lastColumn++;
      if(res[r] == null) res[r] = new int[k];
      res[r][c] = i;
    }
    
    return res;
  }
  
  private int BuildMatrixOrder(int[][] matrixOrder, Stack<int> stack, int pos)
  {
    var c = 0;
    while(stack.Count > 0)
    {
      var v = stack.Pop();
      matrixOrder[v] ??= new int[2] { -1, -1 };
      matrixOrder[v][pos] = c++;
    }
    
    return c-1;
  }
  
  bool TopologicalSort(IReadOnlyList<List<int>> g, Stack<int> stack)
  {
    var visited = new bool[g.Count];
    var cycle = new bool[g.Count];
    
    bool DFS(int v)
    {
      if(cycle[v]) return false;
      if(visited[v]) return true;
      
      visited[v] = true;
      cycle[v] = true;
      
      if(g[v] != null)
        if (g[v].Any(adjv => !DFS(adjv)))
          return false;
        
      stack.Push(v);
      cycle[v] = false;
      return true;
    }
    
    for(int i = 1; i < g.Count; i++)
      if(!DFS(i)) return false;
    
    return true;
  }
}