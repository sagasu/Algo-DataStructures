using System;
using System.Collections.Generic;
using System.Linq;

public class BestTeamWithNoConflicts {
    List<Player> teamList=new List<Player>();
    public int BestTeamScore(int[] scores, int[] ages) {
        var length=ages.Length;
        var result=0;
        var dp=new int[length];
        for(int i=0;i<length;i++){
            var item=new Player{score=scores[i],age=ages[i]};
            teamList.Add(item);
        }
        teamList=teamList.OrderBy(team=>team.age).ThenBy(team=>team.score).ToList();
        for(var i=0;i<length;i++){
            dp[i] = teamList[i].score;
            for(var j = 0; j < i; j++) {
                if(teamList[j].age==teamList[i].age){
                    dp[i]=Math.Max(dp[i],dp[j]+teamList[i].score);
                }
                else if(teamList[j].score <= teamList[i].score && teamList[j].age<teamList[i].age)
                    dp[i] = Math.Max(dp[i], dp[j] + teamList[i].score);
            }
            result = Math.Max(result, dp[i]);
        }
        return result;;
    }

    class Player{
    public int score;
    public int age;
    }
}