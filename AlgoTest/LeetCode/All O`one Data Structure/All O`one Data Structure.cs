using System.Collections.Generic;

namespace AlgoTest.LeetCode.All_O_one_Data_Structure;

public class AllOne
{
    Dictionary<int,LinkedList<string>> map;
    Dictionary<string,(int count,LinkedListNode<string> node)> nodes;
    SortedSet<int> count;

    public AllOne() {
        map = new  Dictionary<int,LinkedList<string>>();
        nodes = new Dictionary<string,(int count,LinkedListNode<string> node)>();
        count = new SortedSet<int>();
    }

    public void Inc(string key) {
        
        if(!nodes.ContainsKey(key)){
            var newnode = new LinkedListNode<string>(key);
            var cnt = 1;
            nodes.Add(key,(cnt,newnode));
            if(!map.ContainsKey(1)){
                map.Add(1,new LinkedList<string>());
            }
            map[1].AddFirst(newnode);
            count.Add(1);
        }
        else{
            var item = nodes[key];
            var curCount = item.count;
            var prevNode = item.node;
            map[curCount].Remove(prevNode);
            if(map[curCount].Count==0){
            map.Remove(curCount);
            count.Remove(curCount);
            }
            var newCount = curCount+1;
            var newnode = new LinkedListNode<string>(key);
            nodes[key] = (newCount,newnode);
            if(!map.ContainsKey(newCount)){
                map.Add(newCount,new LinkedList<string>());
            }
            map[newCount].AddFirst(newnode);
            count.Add(newCount);
        }
    }

    public void Dec(string key) {
        
        var item = nodes[key];
        var curCount = item.count;
        var prevNode = item.node; 
        map[curCount].Remove(prevNode);
        if(map[curCount].Count==0){
            map.Remove(curCount);
            count.Remove(curCount);
        }
        if(curCount == 1){
            nodes.Remove(key); 
        } 
        else if(curCount > 1){
            var newCount = curCount-1;
            var newnode = new LinkedListNode<string>(key);
            nodes[key] = (newCount,newnode);
            if(!map.ContainsKey(newCount)){
                map.Add(newCount,new LinkedList<string>());
            }
            map[newCount].AddFirst(newnode);
            count.Add(newCount); 
        }
         
    }

    public string GetMaxKey() {
        if(count.Count == 0){
            return "";
        }
        return map[count.Max].Last.Value;
    }

    public string GetMinKey() {
        if(count.Count == 0){
            return "";
        }
        return map[count.Min].Last.Value;
    }
}