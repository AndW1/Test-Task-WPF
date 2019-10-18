﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskWPF.Models
{
   public class TaskNodeContext: DbContext
    {
        public TaskNodeContext():base("DefaultConnection")
        {

        }

        public DbSet<TaskNode> TaskNodes { get; set; }
    }
}
