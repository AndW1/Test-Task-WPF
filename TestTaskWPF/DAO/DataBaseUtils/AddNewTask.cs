using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TestTaskWPF.Models;

namespace TestTaskWPF.DAO.DataBaseUtils
{
    public class AddNewTask : IDbUtils
    {
        private TaskNodeContext _taskNodeContext;
        private TaskNode _taskNode;
      
        public AddNewTask(TaskNodeContext taskNodeContext, TaskNode taskNode)
        {
            this._taskNodeContext = taskNodeContext;
            this._taskNode = taskNode;
            this._taskNode.Status = SetStatus(taskNode);
        }


        public void Execute()
        {      
            try
              {
               
                _taskNodeContext.TaskNodes.Add(_taskNode);

                _taskNodeContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

       private string SetStatus(TaskNode task)
        {
            if (task.IsStart)
            {
                return "Не начата";
            }
            else if (task.IsProgress)
            {
                return "В работе";
            }
            else
            {
                return "Выполнена";
            }
        }

    }
}
