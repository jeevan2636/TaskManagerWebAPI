using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManger.Entities;

namespace TaskManger.BAL
{
    public interface IParentTaskServices
    {

        ParentTaskEntity GetTaskById(int parenttaskId);
        IEnumerable<ParentTaskEntity> GetAllTasks();
        int CreateTask(ParentTaskEntity parenttaskEntity);
        bool UpdateTask(int parenttaskId, ParentTaskEntity parenttaskEntity);
        bool DeleteTask(int parenttaskId);
    }
}
