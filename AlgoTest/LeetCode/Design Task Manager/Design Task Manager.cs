using System.Collections.Generic;

public class Task{
    public int userId;
    public int taskId;
    public int priority;

    public Task(int userId ,int taskId, int priority) {
        this.userId = userId;
        this.taskId = taskId;
        this.priority = priority;
    }
}

public class TaskManager {

    SortedSet<Task> task_set;
    Dictionary<int, Task> idTotask_map;

    public TaskManager(IList<IList<int>> tasks) {
        task_set = new SortedSet<Task>(new TaskComparer());
        idTotask_map = new Dictionary<int, Task>();

        for (int i = 0; i < tasks.Count; i++) {
            Task t = new Task(tasks[i][0], tasks[i][1], tasks[i][2]);
            task_set.Add(t);
            if (!idTotask_map.ContainsKey(tasks[i][1])) {
                idTotask_map[tasks[i][1]] = t;
            }
        }
    }
    
    public void Add(int userId, int taskId, int priority) {
        Task t = new Task(userId, taskId, priority);
        task_set.Add(t);
        idTotask_map[taskId] = t;
    }
    
    public void Edit(int taskId, int newPriority) {
        Task t = idTotask_map[taskId];
        task_set.Remove(t);
        t.priority = newPriority;
        task_set.Add(t);
    }
    
    public void Rmv(int taskId) {
        Task t = idTotask_map[taskId];
        task_set.Remove(t);
        idTotask_map.Remove(taskId);
    }
    
    public int ExecTop() {
        if (task_set.Count == 0) return -1;
        Task maxt = task_set.Max;
        int maxId = maxt.userId;
        Rmv(maxt.taskId);
        return maxId;
    }

    private class TaskComparer : IComparer<Task> {
        public int Compare(Task a, Task b) {
            if (a.priority != b.priority) {
                return a.priority.CompareTo(b.priority);
            }
            return a.taskId.CompareTo(b.taskId);
        }
    }
}