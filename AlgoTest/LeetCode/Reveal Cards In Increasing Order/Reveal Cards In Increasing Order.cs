using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoTest.LeetCode.Reveal_Cards_In_Increasing_Order;

public class Reveal_Cards_In_Increasing_Order
{
    public int[] DeckRevealedIncreasing(int[] deck) {
        var n = deck.Length;
        Array.Sort(deck);

        LinkedList<int> list = new();
        list.AddLast(deck[n - 1]);

        for(var i = n - 2; i >= 0; i--)
        {
            list.AddFirst(list.Last.Value);
            list.RemoveLast();
            list.AddFirst(deck[i]);
        }

        return list.ToArray();
    }
}