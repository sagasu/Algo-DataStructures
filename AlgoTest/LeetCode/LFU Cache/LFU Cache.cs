using System.Collections.Generic;
using System.Linq;

public class LFUCache {

    private Dictionary<int, Pair<int, Pair<int, int>>> cache;

    private Dictionary<int, List<Pair<int, int>>> frequencies;
    
    private int minf;
    private int capacity;

    public void Insert(int key, int frequency, int value) {
        if (!frequencies.ContainsKey(frequency)) 
            frequencies[frequency] = new List<Pair<int, int>>();
        
        frequencies[frequency].Add(new Pair<int, int>(key, value));
        cache[key] = new Pair<int, Pair<int, int>>(frequency, frequencies[frequency].Last());
    }

    public LFUCache(int capacity) {
        cache = new Dictionary<int, Pair<int, Pair<int, int>>>();
        frequencies = new Dictionary<int, List<Pair<int, int>>>();
        minf = 0;
        this.capacity = capacity;        
    }    
    
    public int Get(int key) {
        if (!cache.ContainsKey(key)) 
            return -1;
        
        var pair = cache[key];
        int f = pair.Key;
        var kv = pair.Value;
        frequencies[f].Remove(kv);
        if (frequencies[f].Count == 0 && minf == f)
            ++minf;
        
        Insert(key, f + 1, kv.Value);
        return kv.Value;            
    }
    
    public void Put(int key, int value) {
        if (capacity <= 0)
            return;
        
        if (cache.ContainsKey(key)) {
            var it = cache[key];
            it.Value.Value = value;
            Get(key);
            return;
        }        
        if (capacity == cache.Count) {
            cache.Remove(frequencies[minf].First().Key);
            frequencies[minf].RemoveAt(0);
        }
        minf = 1;
        Insert(key, 1, value);               
    }

    private class Pair<TKey, TValue> {
        public TKey Key;
        public TValue Value;

        public Pair(TKey key, TValue value) {
            Key = key;
            Value = value;
        }
    }
}
