using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetVet.Models
{
    public class PaginationParams
    {
        const int maxPageSize = 100;

        public int pageNumber { get; set; } = 1;

        private int _pageSize = 10;

        public int pageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
    }
}
