using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskWPF.Models
{
  public class TaskNode
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateFinish { get; set; }
        public DateTime? DateCreate { get; set; }
        public string Status { get; set; }
        public bool IsStart { get; set; }
        public bool IsFinish { get; set; }
        public bool IsProgress { get; set; }

    }
}


