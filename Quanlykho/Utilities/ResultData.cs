using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quanlykho.Utilities
{
    public class ResultData<T>
    {
        public int TotalPage { get; set; } = 0;
        public int PageCount { get; set; } = 0;
        public int TotalCount { get; set; } = 0;
        public IQueryable<T> ListData { get; set; }
    }
}
