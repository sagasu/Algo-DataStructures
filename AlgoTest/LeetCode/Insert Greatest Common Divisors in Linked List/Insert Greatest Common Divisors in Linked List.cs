using AlgoTest.LeetCode.RotateList;

namespace AlgoTest.LeetCode.Insert_Greatest_Common_Divisors_in_Linked_List;

public class Insert_Greatest_Common_Divisors_in_Linked_List
{
    public ListNode InsertGreatestCommonDivisors(ListNode head) {
        var cur=head;
        while(cur.next!=null){
            var newNode=new ListNode(GCD(cur.val,cur.next.val));
            newNode.next=cur.next;
            cur.next=newNode;
            cur=cur.next.next;
        }
        return head;
    }
    int GCD(int a,int b) => b==0 ? a : GCD(b,a%b);
    
}