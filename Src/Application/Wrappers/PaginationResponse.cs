using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Wrappers
{
    public class PaginationResponse<T> where T: class
    {
        public PaginationResponse(int pageIndex, int pagesize, int count, IEnumerable<T> result)
        {
            PageIndex = pageIndex;
            Pagesize = pagesize;
            Count = count;
            Result = result;
        }

        public int PageIndex { get; set; }
        public int Pagesize { get; set; }
        public int Count { get; set; }
        public IEnumerable<T> Result { get; set; }
    }
}
