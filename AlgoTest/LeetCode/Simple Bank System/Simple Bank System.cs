namespace AlgoTest.LeetCode.Simple_Bank_System;

public class Bank
{
    private long[] bal;
    private int n;

    public Bank(long[] balance)
    {
        bal = balance;
        n = balance.Length;
    }

    private bool Valid(int acc)
    {
        return acc > 0 && acc <= n;
    }

    public bool Transfer(int from, int to, long amt)
    {
        if (!Valid(from) || !Valid(to) || bal[from - 1] < amt)
            return false;
        bal[from - 1] -= amt;
        bal[to - 1] += amt;
        return true;
    }

    public bool Deposit(int acc, long amt)
    {
        if (!Valid(acc))
            return false;
        bal[acc - 1] += amt;
        return true;
    }

    public bool Withdraw(int acc, long amt)
    {
        if (!Valid(acc) || bal[acc - 1] < amt)
            return false;
        bal[acc - 1] -= amt;
        return true;
    }
}