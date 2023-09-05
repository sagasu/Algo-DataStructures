using System.Collections.Generic;

namespace AlgoTest.LeetCode.Copy_List_with_Random_Pointer;

public class Copy_List_with_Random_Pointer
{
    public Node CopyRandomList(Node head) {
        
        if(head == null)
            return null;
        
        var dic = new Dictionary<Node, Node>();
        
        var curr = head;
        while(curr != null)
        {
            dic.Add(curr, new Node(curr.val));
            curr = curr.next;
        }
        
        curr = head;
        while(curr != null)
        {
            dic[curr].next = curr.next == null? null : dic[curr.next];
            dic[curr].random = curr.random == null? null : dic[curr.random];
            curr = curr.next;
        }
        
        return dic[head];
        
        
    }
    
    public class Node {
        public int val;
        public Node next;
        public Node random;
    
        public Node(int _val) {
            val = _val;
            next = null;
            random = null;
        }
    }
}