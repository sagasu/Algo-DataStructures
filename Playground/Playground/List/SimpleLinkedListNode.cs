namespace Playground.List
{
    public class SimpleLinkedListNode<T>
    {
        public T Current;
        public SimpleLinkedListNode<T> Next; 
        public SimpleLinkedListNode<T> Previous;

        public SimpleLinkedListNode<T> Add(T t)
        {
            Current = t;
            Next = new SimpleLinkedListNode<T> {Previous = this};
            return Next;
        }

        public void Remove()
        {
            if(Previous != null)
                Previous.Next = Next;

            if(Next != null)
                Next.Previous = Previous;
        }
    }
}
