using System;
using System.Collections.Generic;
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
        private string status;

        public AddNewTask(TaskNodeContext taskNodeContext, TaskNode taskNode)
        {
            this._taskNodeContext = taskNodeContext;
            this._taskNode = taskNode;
        }



        public void Execute()
        {
            SetStatus();
            try
            {
                _taskNodeContext.TaskNodes.Add(new TaskNode
                {
                    Title = _taskNode.Title,
                    DateCreate = _taskNode.DateCreate,
                    Status = status,
                    DateFinish = _taskNode.DateFinish,
                    DateStart = _taskNode.DateStart,
                    IsFinish = _taskNode.IsFinish,
                    IsProgress = _taskNode.IsProgress,
                    IsStart = _taskNode.IsStart

                });
                _taskNodeContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        private void SetStatus()
        {
            if (_taskNode.IsStart)
            {
                status = "Не начата";
            }
            if (_taskNode.IsProgress)
            {
                status = "В работе";
            }
            if (_taskNode.IsFinish)
            {
                status = "Выполнена";
            }
        }
    }
}
