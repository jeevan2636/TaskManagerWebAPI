using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManger.Entities;

namespace TaskManger.BAL
{
    public interface ITaskServices
    {
        TaskEntity GetTaskById(int taskId);
        IEnumerable<VIEW_TASKManagerEntity> GetAllTasks();
        int CreateTask(TaskEntity taskEntity);
        bool UpdateTask(int taskId, TaskEntity taskEntity);
        bool DeleteTask(int taskId);
    }
}
