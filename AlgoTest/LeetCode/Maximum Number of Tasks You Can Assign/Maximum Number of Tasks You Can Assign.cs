using System;
using System.Collections.Generic;

namespace AlgoTest.LeetCode.Maximum_Number_of_Tasks_You_Can_Assign;

public class Maximum_Number_of_Tasks_You_Can_Assign
{
    public int MaxTaskAssign(int[] tasks, int[] workers, int pills, int strength) {
        Array.Sort(tasks);
        Array.Sort(workers);

        int left = 0, right = Math.Min(tasks.Length, workers.Length);
        int answer = 0;

        while (left <= right) {
            int mid = left + (right - left) / 2;
            if (CanAssign(mid, tasks, workers, pills, strength)) {
                answer = mid;
                left = mid + 1;
            } else {
                right = mid - 1;
            }
        }

        return answer;
    }

    private bool CanAssign(int k, int[] tasks, int[] workers, int pills, int strength) {
        LinkedList<int> availableWorkers = new LinkedList<int>();
        for (int i = workers.Length - k; i < workers.Length; i++) {
            availableWorkers.AddLast(workers[i]);
        }

        int remainingPills = pills;

        for (int i = k - 1; i >= 0; i--) {
            int task = tasks[i];

            if (availableWorkers.Last != null && availableWorkers.Last.Value >= task) {
                availableWorkers.RemoveLast();
            } else if (remainingPills > 0) {
                LinkedListNode<int> node = availableWorkers.First;
                while (node != null && node.Value + strength < task) {
                    node = node.Next;
                }
                if (node == null) return false;
                availableWorkers.Remove(node);
                remainingPills--;
            } else {
                return false;
            }
        }

        return true;
    }
}