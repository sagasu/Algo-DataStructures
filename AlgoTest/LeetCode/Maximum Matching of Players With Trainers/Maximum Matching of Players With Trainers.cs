using System;

namespace AlgoTest.LeetCode.Maximum_Matching_of_Players_With_Trainers;

public class Maximum_Matching_of_Players_With_Trainers
{
    public int MatchPlayersAndTrainers(int[] players, int[] trainers) {
        Array.Sort(players);
        Array.Sort(trainers);

        var count = 0; 
        int i=0, j=0;

        while (i < players.Length && j < trainers.Length) {
            if (players[i] <= trainers[j]) {
                count++;
                i++;
                j++;
            } else 
                j++;
            
        }
        return count;
    }
}