using System.Collections;
using System.Collections.Generic;

namespace Mgi.Framework.Core
{
    public class PageResult<T>  where T : class
    {
        public int TotalRows { get; set; }
        public int PageCount { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public IEnumerable<T> Items { get; set; }
    }
}
