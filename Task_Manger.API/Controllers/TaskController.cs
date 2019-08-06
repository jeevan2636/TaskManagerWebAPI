using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using TaskManger.BAL;
using TaskManger.Entities;

namespace Task_Manger.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")] // tune to your needs

    public class TaskController : ApiController
    {
        private readonly ITaskServices _taskServices;
        private readonly IParentTaskServices _ParenttaskServices;
        public TaskController()
        {
            _taskServices = new TaskServices();
            _ParenttaskServices = new ParentTaskServices();
        }

        // GET: api/Task
        public HttpResponseMessage Get()
        {
            try
            {
                var tasks = _taskServices.GetAllTasks();
                if (tasks != null)
                {
                    var taskEntities = tasks as List<VIEW_TASKManagerEntity> ?? tasks.ToList();
                    if (taskEntities.Any())
                        return Request.CreateResponse(HttpStatusCode.OK, taskEntities);
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Tasks not found");
        }

        // GET: api/Task/5
        public HttpResponseMessage Get(int id)
        {

            try
            {
                var task = _taskServices.GetTaskById(id);
                if (task != null)
                    return Request.CreateResponse(HttpStatusCode.OK, task);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No user found for this id");
            
        }

        // POST: api/Task
        public void Post([FromBody]TaskEntity taskEntity)
        {
            try
            {
                taskEntity.Parent_ID = _ParenttaskServices.CreateTask(new ParentTaskEntity() { Parent_Task=taskEntity.Parent_Task});
               _taskServices.CreateTask(taskEntity);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        // PUT: api/Task/5
        public bool Put(int id, [FromBody]TaskEntity taskEntity)
        {
          return _taskServices.UpdateTask(id, taskEntity);

        }

        // DELETE: api/Task/5
        public void Delete(int id)
        {
             _taskServices.DeleteTask(id);

        }
    }
}
