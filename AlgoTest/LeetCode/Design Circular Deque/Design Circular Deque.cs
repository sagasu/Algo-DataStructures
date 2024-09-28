namespace AlgoTest.LeetCode.Design_Circular_Deque;

public class MyCircularDeque
{
    private int front = -1;
    private int rear = -1;
    private int[] arr;
    private int size = 0;
    
    /** Initialize your data structure here. Set the size of the deque to be k. */
    public MyCircularDeque(int k) {
        arr = new int[k];
    }
    
    /** Adds an item at the front of Deque. Return true if the operation is successful. */
    public bool InsertFront(int value) {
        if(size == arr.Length)
            return false;
        
        front = (front + arr.Length - 1) % arr.Length;
        
        // when the queue is empty, front and rear will point at the same position  after the insertion.
        if(size == 0)
            rear = front;
        
        arr[front] = value;
        size++;
        return true;
    }
    
    /** Adds an item at the rear of Deque. Return true if the operation is successful. */
    public bool InsertLast(int value) {
        if(size == arr.Length)
            return false;
        
        rear = (rear + 1) % arr.Length;
        
        if(size == 0)
            front = rear;
        
        arr[rear] = value;
        size++;
        return true;
    }
    
    /** Deletes an item from the front of Deque. Return true if the operation is successful. */
    public bool DeleteFront() {
        if(IsEmpty())
            return false;
        
        front = (front + 1) % arr.Length;
        size--;
        return true;
    }
    
    /** Deletes an item from the rear of Deque. Return true if the operation is successful. */
    public bool DeleteLast() {
        if(IsEmpty())
            return false;
        
        rear = (rear + arr.Length - 1) % arr.Length;
        size--;
        return true;
    }
    
    /** Get the front item from the deque. */
    public int GetFront() {
        return size == 0? -1 : arr[front];
    }
    
    /** Get the last item from the deque. */
    public int GetRear() {
        return size == 0? -1: arr[rear];
    }
    
    /** Checks whether the circular deque is empty or not. */
    public bool IsEmpty() {
        return size == 0;
    }
    
    /** Checks whether the circular deque is full or not. */
    public bool IsFull() {
        return size == arr.Length;
    }
}