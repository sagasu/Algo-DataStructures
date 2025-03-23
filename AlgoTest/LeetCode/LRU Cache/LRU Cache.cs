using System.Collections.Generic;

public class LRUCache 
{
    private readonly int _capacity;
    private readonly Dictionary<int, LinkedListNode<KeyValuePair<int, int>>> _cache;
    private readonly LinkedList<KeyValuePair<int, int>> _lru;

    public LRUCache(int capacity) 
    {
        _capacity = capacity;        
        _cache = new();
        _lru = new();
    }
    
    public int Get(int key) 
    {
        if (!_cache.TryGetValue(key, out var node))
        {
            return -1;
        }
        
        _lru.Remove(node);
        _cache[key] = _lru.AddFirst(node.Value);
        
        return node.Value.Value;        
    }
    
    public void Put(int key, int value) 
    {
        if (_cache.TryGetValue(key, out var node))
        {
            _lru.Remove(node);
            _cache.Remove(key);
        }
        
        node = _lru.AddFirst(new KeyValuePair<int, int>(key, value));
        _cache[key] = node;
        
        if (_lru.Count > _capacity)
        {
            node = _lru.Last;            
            _lru.RemoveLast();
            _cache.Remove(node.Value.Key);            
        }
    }
}


/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */