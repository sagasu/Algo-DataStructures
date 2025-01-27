using System.Collections.Generic;
using System.Linq;

namespace AlgoTest.LeetCode.Course_Schedule_IV;

public class Course_Schedule_IV
{
    public IList<bool> CheckIfPrerequisite(int numCourses, int[][] prerequisites, int[][] queries) {
        var reachable = new bool[numCourses, numCourses];
        for (var i = 0; i < numCourses; i++) {
            reachable[i, i] = true;
        }
        foreach (var e in prerequisites) {
            reachable[e[0], e[1]] = true;
        }
        for (var k = 0; k < numCourses; k++) {
            for (var i = 0; i < numCourses; i++) {
                for (var j = 0; j < numCourses; j++) {
                    reachable[i, j] = reachable[i, j] || (reachable[i, k] && reachable[k, j]);
                }
            }
        }
        return queries.Select(q => reachable[q[0], q[1]]).ToList();
    }
}