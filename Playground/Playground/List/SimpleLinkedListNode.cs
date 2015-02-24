namespace Playground.List
{
    public class SimpleLinkedListNode<T>
    {
        public T Current;
        public SimpleLinkedListNode<T> Next; 
        public SimpleLinkedListNode<T> Previous;

        public SimpleLinkedListNode(T current, SimpleLinkedListNode<T> next, SimpleLinkedListNode<T> previous)
        {
            Current = current;
            Next = next;
            Previous = previous;

            if (Next != null)
                Next.Previous = this;

            if (Previous != null)
                Previous.Next = this;
        }

        public SimpleLinkedListNode<T> Add(T t)
        {
            Next =  new SimpleLinkedListNode<T>(t,Next,this);
            return Next;
        }

        public SimpleLinkedListNode<T> Remove()
        {
            if(Previous != null)
                Previous.Next = Next;

            if(Next != null)
                Next.Previous = Previous;

            return Previous == null ? Next : null;
        }
    }
}
