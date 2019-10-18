using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskWPF.DAO.SelectByFilter;
using TestTaskWPF.Models;

namespace TestTaskWPF.DAO.DataBaseSelectByFilter
{
    class SelectByFinished : IFilter
    {
        private TaskNodeContext _taskNodeContext;


        public SelectByFinished(TaskNodeContext taskNodeContext)
        {
            this._taskNodeContext = taskNodeContext;
        }


        public IEnumerable<TaskNode> Execute()
        {
            try
            {
                return _taskNodeContext.TaskNodes.Where(n => n.IsFinish == true).Select(n => n).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
