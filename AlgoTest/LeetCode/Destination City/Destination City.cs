using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AlgoTest.LeetCode.Destination_City;

public class Destination_City
{
    public string DestCity(IList<IList<string>> paths)
    {
        var dic = new HashSet<string>();
        foreach (var path in paths)
            dic.Add(path[0]);

        foreach (var path in paths)
            if (dic.Add(path[1])) return path[1];

        throw new InvalidDataException("not found");
    }
}