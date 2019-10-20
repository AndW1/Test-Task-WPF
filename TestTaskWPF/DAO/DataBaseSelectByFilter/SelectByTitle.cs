using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskWPF.DAO.SelectByFilter;
using TestTaskWPF.Models;

namespace TestTaskWPF.DAO.DataBaseSelectByFilter
{
    class SelectByTitle : IFilter
    {
        private TaskNodeContext _taskNodeContext;
        private string _title;

        public SelectByTitle(TaskNodeContext taskNodeContext, string title)
        {
            this._taskNodeContext = taskNodeContext;
            this._title = title;
        }


        public IEnumerable<TaskNode> Execute()
        {
            try
            {
                return _taskNodeContext.TaskNodes.Where(n => n.Title.StartsWith(_title)).Select(n => n).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
