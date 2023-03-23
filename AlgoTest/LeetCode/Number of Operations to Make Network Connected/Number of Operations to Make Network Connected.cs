public class NumberofOperationstoMakeNetworkConnected {
    public int MakeConnected(int n, int[][] connections) {
        if(connections.Length < n - 1) return -1;
        var uf = new UnionFind<int>();
        for(int i = 0; i < n; i++) uf.Union(i, i);
        foreach(var con in connections) uf.Union(con[0], con[1]);
        return uf.GroupCount() - 1;
    }

        class UnionFind<T>
    {
        private Dictionary<T, T> parentMap;
        private int groupCount;
        
        public UnionFind()
        {
            groupCount = 0;
            parentMap = new Dictionary<T, T>();
        }
        
        public void Union(T item1, T item2)
        {
            T group1 = Find(item1), group2 = Find(item2);
            if(!group1.Equals(group2))
            {
                parentMap[group1] = group2;
                groupCount--;
            }
        }
        
        public T Find(T item)
        {
            if(!parentMap.ContainsKey(item)) 
            {
                groupCount++;
                parentMap[item] = item;
            }
            
            if(!parentMap[item].Equals(item)) parentMap[item] = Find(parentMap[item]);
            return parentMap[item];
        }
        
        public int GroupCount()
        {
            return groupCount;
        }
    }
}