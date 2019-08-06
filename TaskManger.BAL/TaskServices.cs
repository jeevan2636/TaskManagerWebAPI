using AutoMapper;
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
    public class TaskServices : ITaskServices
    {
        private readonly UnitOfWork _unitOfWork;
        public TaskServices()
        {
            _unitOfWork = new UnitOfWork();
        }


        public int CreateTask(TaskEntity taskEntity)
        {
            using (var scope = new TransactionScope())
            {
                var task = new TaskMan.DAL.Task
                {
                    TaskName = taskEntity.TaskName,
                    Parent_ID = taskEntity.Parent_ID,
                    Start_Date = taskEntity.Start_Date,
                    End_Date = taskEntity.End_Date,
                    Priority = taskEntity.Priority,
                };
                _unitOfWork.TaskRepository.Insert(task);
                _unitOfWork.Save();
                scope.Complete();
                return task.Task_ID;
            }
        }

        public bool DeleteTask(int taskId)
        {
            var success = false;
            if (taskId > 0)
            {
                using (var scope = new TransactionScope())
                {
                    var task = _unitOfWork.TaskRepository.GetByID(taskId);
                    if (task != null)
                    {
                        _unitOfWork.TaskRepository.Delete(task);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }

        public IEnumerable<VIEW_TASKManagerEntity> GetAllTasks()
        {
            var tasks = _unitOfWork.TaskSearchRepository.GetAll().ToList();
            if (tasks.Any())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<TaskMan.DAL.VIEW_TASKManger, VIEW_TASKManagerEntity>();
                }
                );
                IMapper mapper = config.CreateMapper();
                var tasksModel = mapper.Map<List<TaskMan.DAL.VIEW_TASKManger>, List<VIEW_TASKManagerEntity>>(tasks);
                return tasksModel;
            }
            return null;
        }

        public TaskEntity GetTaskById(int taskId)
        {
            var task = _unitOfWork.TaskRepository.GetByID(taskId);
            if (task != null)
            {
                var config = new MapperConfiguration(cfg =>
               {
                   cfg.CreateMap<TaskMan.DAL.Task, TaskEntity>();
               }
                );
                IMapper mapper = config.CreateMapper();
                var taskModel = mapper.Map<TaskMan.DAL.Task, TaskEntity>(task);
                return taskModel;
            }
            return null;
        }

        public bool UpdateTask(int taskId, TaskEntity taskEntity)
        {
            var success = false;
            if (taskEntity != null)
            {
                using (var scope = new TransactionScope())
                {
                    var task = _unitOfWork.TaskRepository.GetByID(taskId);
                    if (task != null)
                    {
                        task.TaskName = taskEntity.TaskName;
                        task.Start_Date = taskEntity.Start_Date;
                        task.End_Date = taskEntity.End_Date;
                        task.Priority = taskEntity.Priority;
                        _unitOfWork.TaskRepository.Update(task);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }
    }
}
