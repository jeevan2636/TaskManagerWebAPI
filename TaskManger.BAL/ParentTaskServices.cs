using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using TaskMan.DAL;
using TaskManger.Entities;

namespace TaskManger.BAL
{
    public class ParentTaskServices : IParentTaskServices
    {
        private readonly UnitOfWork _unitOfWork;
        public ParentTaskServices()
        {
            _unitOfWork = new UnitOfWork();
        }
        public int CreateTask(ParentTaskEntity parenttaskEntity)
        {
            using (var scope = new TransactionScope())
            {
                var task = new TaskMan.DAL.ParentTask
                {
                    Parent_Task = parenttaskEntity.Parent_Task,
                };
                _unitOfWork.ParentTaskRepository.Insert(task);
                _unitOfWork.Save();
                scope.Complete();
                return task.Parent_ID;
            }
        }

        public bool DeleteTask(int parenttaskId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ParentTaskEntity> GetAllTasks()
        {
            throw new NotImplementedException();
        }

        public ParentTaskEntity GetTaskById(int parenttaskId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateTask(int parenttaskId, ParentTaskEntity parenttaskEntity)
        {
            throw new NotImplementedException();
        }
    }
}
