using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskWPF.DAO.DataBaseUtils;
using TestTaskWPF.DAO.SelectByFilter;
using TestTaskWPF.Models;

namespace TestTaskWPF.DAO.DataAccessObject
{
     public class DataAccessObject : IDataAccess
      {
        private IEnumerable<TaskNode> _result;

        private IDbUtils _dbUtils;

        private IFilter _filter; 

        public DataAccessObject(IDbUtils dbUtils)
        {
            this._dbUtils = dbUtils;
        }

        public DataAccessObject(IFilter filter)
        {      
            this._filter = filter;
        }


        public IEnumerable<TaskNode> ExecuteFilter()
        {
            _result = _filter.Execute();
            return _result;
        }

        public void ExecuteUtils()
        {
            _dbUtils.Execute();
        }
    }
}
