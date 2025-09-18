using System.Collections.Generic;

namespace AlgoTest.LeetCode.Design_Task_Manager;

public class TaskManager
{
    private Dictionary<int, (int userId, int priority)> taskMap;
    private SortedSet<(int priority, int taskId, int userId)> taskSet;
    public TaskManager(IList<IList<int>> tasks) {
        taskMap = new Dictionary<int, (int, int)>();
        taskSet = new SortedSet<(int, int, int)>(new TaskComparer());

        foreach (var t in tasks) {
            int userId = t[0], taskId = t[1], priority = t[2];
            taskMap[taskId] = (userId, priority);
            taskSet.Add((priority, taskId, userId));
        }
    }
    
    public void Add(int userId, int taskId, int priority) {
        taskMap[taskId] = (userId, priority);
        taskSet.Add((priority, taskId, userId));
    }
    
    public void Edit(int taskId, int newPriority) {
        if (!taskMap.ContainsKey(taskId)) return;
        var (userId, oldPriority) = taskMap[taskId];

        taskSet.Remove((oldPriority, taskId, userId));

        taskMap[taskId] = (userId, newPriority);
        taskSet.Add((newPriority, taskId, userId));
    }
    
    public void Rmv(int taskId) {
        if (!taskMap.ContainsKey(taskId)) return;
        var (userId, priority) = taskMap[taskId];
        taskSet.Remove((priority, taskId, userId));
        taskMap.Remove(taskId);
    }
    
    public int ExecTop() {
        if (taskSet.Count == 0) return -1;

        var top = taskSet.Max; 
        taskSet.Remove(top);
        taskMap.Remove(top.taskId);
        return top.userId;
    }
    private class TaskComparer : IComparer<(int priority, int taskId, int userId)> {
        public int Compare((int priority, int taskId, int userId) a, (int priority, int taskId, int userId) b) {
            if (a.priority != b.priority)
                return a.priority.CompareTo(b.priority);
            if (a.taskId != b.taskId)
                return a.taskId.CompareTo(b.taskId);
            return a.userId.CompareTo(b.userId);
        }
    }
}