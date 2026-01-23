using System.Collections.Generic;

namespace AlgoTest.LeetCode.Minimum_Pair_Removal_to_Sort_Array_II;

public class Minimum_Pair_Removal_to_Sort_Array_II
{
    public class Node{
        public long val;
        public int originalIndex; 
        public Node prev,next;
        public bool removed=false;

        public Node(long v, int idx){val=v; originalIndex=idx;}
    }

    public int MinimumPairRemoval(int[] nums) 
    {
        int n=nums.Length;
        if(n<2) return 0;

        Node head= new Node(nums[0],0);
        Node curr=head;
        List<Node> nodes= new List<Node>();
        nodes.Add(head);
    
        for(int i=1;i<n;i++){
            Node newNode= new Node(nums[i],i);
            curr.next=newNode;
            newNode.prev=curr;
            curr=newNode;
            nodes.Add(newNode);
        }


        var pq = new PriorityQueue<(long sum, Node left, Node right),(long,int)>();

        int badEdgeCount=0;
        curr=head;
        while(curr!=null && curr.next!=null){
            long sum= curr.val + curr.next.val;
            pq.Enqueue((sum,curr,curr.next),(sum,curr.originalIndex));

            if(curr.val > curr.next.val) badEdgeCount++;
            curr=curr.next;
        }

        int operations=0;

        while(badEdgeCount>0){
            if(pq.Count==0) break;

            var top= pq.Dequeue();
            Node left=top.left;
            Node right=top.right;

            if(left.removed || right.removed) continue;

            if(top.sum != left.val + right.val) continue;

            if(left.prev!=null && left.prev.val>left.val) badEdgeCount--;
            if(left.val>right.val) badEdgeCount--;
            if(right.next!=null && right.val>right.next.val) badEdgeCount--;

            left.val=left.val+right.val;
            right.removed=true;

            left.next=right.next;
            if(left.next!=null) left.next.prev=left;

            if(left.prev!=null && left.prev.val>left.val) badEdgeCount++;
            if(left.next!=null && left.val>left.next.val) badEdgeCount++;

            if(left.prev!=null){
                long s =left.prev.val + left.val;
                pq.Enqueue((s,left.prev,left),(s,left.prev.originalIndex));
            }
            if(left.next!=null){
                long s =left.val + left.next.val;
                pq.Enqueue((s,left,left.next),(s,left.originalIndex));
            }
            operations++;

        }
        return operations;
    }
}