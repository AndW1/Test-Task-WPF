using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskWPF.Models;
using System.Data.Entity;


namespace TestTaskWPF.DAO.DataBaseUtils
{
    class UpdateTaskNode : IDbUtils
    {

        private TaskNodeContext _taskNodeContext;
        private TaskNode _taskNode;

        public UpdateTaskNode(TaskNodeContext taskNodeContext, TaskNode taskNode)
        {
            this._taskNodeContext = taskNodeContext;
            this._taskNode = taskNode;
            
        }

        public void Execute()
        {
            try
            {
                TaskNode tmp = _taskNodeContext.TaskNodes.Where(n => n.Id == _taskNode.Id).Select(n => n).FirstOrDefault();
                tmp = _taskNode;
                _taskNodeContext.SaveChanges();
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
