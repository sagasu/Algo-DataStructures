namespace Playground.Null
{
    public class Cut
    {
        public Cut AssignNullAndReturn(Cut c)
        {
            c = null;
            return c;
        }

        public void AssignNull(Cut c)
        {
            c = null;
        }

        public void SetNull()
        {
            // Cannot do this operation
            //this = null;
        }

    }
}
