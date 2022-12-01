using System.Collections.Generic;

public class StockSpanner 
{
    struct Entry
    {
        public int Val;
        public int Occ;
    }
    Stack<Entry> s;
    public StockSpanner() 
    {
        s = new Stack<Entry>();
    }
    
    public int Next(int price) 
    {
        var occ = 1;
        while(s.Count > 0 && price >= s.Peek().Val)
            occ += s.Pop().Occ;
        
        s.Push(new Entry {Val = price, Occ = occ});
        return occ;
    }
}