//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TaskManger.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class VIEW_TASKManger
    {
        public int Task_ID { get; set; }
        public string TaskName { get; set; }
        public System.DateTime Start_Date { get; set; }
        public System.DateTime End_Date { get; set; }
        public string TaskStartDate { get; set; }
        public string TaskEndDate { get; set; }
        public int Priority { get; set; }
        public int Parent_ID { get; set; }
        public string ParentTaskName { get; set; }
    }
}