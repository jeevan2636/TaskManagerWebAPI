using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace TaskMan.DAL
{
    public interface IUnitOfWork
    {
        
        GenericRepository<Task> TaskRepository
        {
            get;
        }
        GenericRepository<ParentTask> ParentTaskRepository
        {
            get;
        }
        GenericRepository<VIEW_TASKManger> TaskSearchRepository
        {
            get;
        }
        void Save();
    }
}
