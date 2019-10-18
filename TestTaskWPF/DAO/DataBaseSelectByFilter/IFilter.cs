using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskWPF.Models;

namespace TestTaskWPF.DAO.SelectByFilter
{
    public interface IFilter
    {
        IEnumerable<TaskNode> Execute();
    }
}
