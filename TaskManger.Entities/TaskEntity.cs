using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManger.Entities
{
    public class TaskEntity
    {
        public int Task_ID { get; set; }
        public int Parent_ID { get; set; }
        public string TaskName { get; set; }
        public System.DateTime Start_Date { get; set; }
        public System.DateTime End_Date { get; set; }
        public int Priority { get; set; }
        public string Parent_Task { get; set; }

    }
}
