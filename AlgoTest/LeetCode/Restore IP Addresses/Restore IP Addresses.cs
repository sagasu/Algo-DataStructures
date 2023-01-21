public class Solution
{
    public IList<string> RestoreIpAddresses(string s)
    {
        return GetIpAddresses(s, 4);
    }

    private IList<string> GetIpAddresses(string s, int depth)
    {
        if (depth == 0)
            return s == "" ? new List<string> { "" } : new List<string>();

        var list = new List<string>();
        for (var i = 1; i <= (s.Length < 3 ? s.Length : 3); i++)
        {
            var str = s.Substring(0, i);
            if (int.Parse(str) > 255) continue;
            if (str.StartsWith("0") && str.Length > 1) continue;
            var ipAddresses = GetIpAddresses(s.Substring(i), depth - 1);
            string Ip(string x) => $"{str}{(x != "" ? $".{x}" : "")}";
            var result = ipAddresses.Select(Ip).ToList();
            list.AddRange(result);
        }

        return list;
    }
}