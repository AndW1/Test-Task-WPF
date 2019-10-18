using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TestTaskWPF.DAO.SelectByFilter;
using TestTaskWPF.Models;

namespace TestTaskWPF.DAO.DataBaseSelectByFilter
{
    public class SelectAllTask : IFilter
    {
        private TaskNodeContext _taskNodeContext;


        public SelectAllTask(TaskNodeContext taskNodeContext)
        {
            this._taskNodeContext = taskNodeContext;
        }

        public IEnumerable<TaskNode> Execute()
        {          
            try
            {
                return _taskNodeContext.TaskNodes.ToList();
            }
           catch(Exception e)
            {
                throw new Exception(e.Message);
            }      
        }
    }
}
