using System.Collections.Generic;
using System.Linq;

namespace AlgoTest.LeetCode.Get_Watched_Videos_by_Your_Friends;

public class Get_Watched_Videos_by_Your_Friends
{
    public IList<string> WatchedVideosByFriends(IList<IList<string>> watchedVideos, int[][] friends, int id, int level)
    {
        var friendsOfLevel = GetFriendsOfLevel(friends, id, level);

        var res = friendsOfLevel
            .SelectMany(f => watchedVideos[f])
            .GroupBy(v => v)
            .OrderBy(g => g.Count())
            .ThenBy(g => g.Key)
            .Select(g => g.Key)
            .ToList();
        return res;
    }

    int[] GetFriendsOfLevel(int[][] friends, int id, int level)
    {
        var curLevel = 1;
        var curFriends = friends[id];

        while(curLevel != level)
        {
            curFriends = curFriends
                .SelectMany(f => friends[f])
                .Distinct()
                .Where(f => f != id && !curFriends.Contains(f))
                .ToArray();
            curLevel++;
        }

        return curFriends;
    }
}