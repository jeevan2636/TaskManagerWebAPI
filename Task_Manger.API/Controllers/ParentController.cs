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

    public class ParentController : ApiController
    {

        private readonly IParentTaskServices _taskServices;
       public ParentController()
        {
            _taskServices = new ParentTaskServices();
        }        // POST: api/Parent
        public void Post([FromBody]ParentTaskEntity taskEntity)
        {
            try
            {
                _taskServices.CreateTask(taskEntity);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        
    }
}
