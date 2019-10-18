using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskWPF.DAO.SelectByFilter;
using TestTaskWPF.Models;

namespace TestTaskWPF.DAO.DataBaseSelectByFilter
{
    class SelectByFinishDate : IFilter
    {
        private TaskNodeContext _taskNodeContext;
        private DateTime _targetDate;

        public SelectByFinishDate(TaskNodeContext taskNodeContext, DateTime targetDate)
        {
            this._taskNodeContext = taskNodeContext;
            this._targetDate = targetDate;
        }

        public IEnumerable<TaskNode> Execute()
        {
            try
            {
                return _taskNodeContext.TaskNodes.Where(n => n.DateFinish == _targetDate).Select(n => n).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
