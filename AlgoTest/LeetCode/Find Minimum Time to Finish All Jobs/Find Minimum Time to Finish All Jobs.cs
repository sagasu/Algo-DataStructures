using System;
using System.Linq;

namespace AlgoTest.LeetCode.Find_Minimum_Time_to_Finish_All_Jobs;

public class Find_Minimum_Time_to_Finish_All_Jobs
{
    public int MinimumTimeRequired(int[] jobs, int k) {
        Array.Sort(jobs);
        var left = jobs.Max();
        var right = jobs.Sum();

        while(left< right){
            var mid = left+ (right-left)/2;
            if(CanAssign(jobs,0,k,mid)){
                right = mid;
            }else{
                left = mid+1;
            }
        }
        
        return left;
    }
    private bool CanAssign(int[] jobs, int index, int k, int maxTime){
        var workers = new int[k];
        return BackTrack( jobs, index, workers, maxTime);
    }
    private bool BackTrack(int[] jobs, int index, int[] workers, int maxTime){
        if(index == jobs.Length){
            return true;
        }

        for(var i = 0; i<workers.Length; i++){
            if(workers[i]+jobs[index]<= maxTime){
                workers[i]+=jobs[index];
                if(BackTrack(jobs,index+1,workers,maxTime)){
                    return true;
                }
                workers[i]-=jobs[index];
            }
            if(workers[i]==0 || workers[i]+jobs[index]== maxTime){
                break;
            }
        }
        return false;
    }
}