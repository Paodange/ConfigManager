using System.Collections.Generic;

namespace Mgi.Framework.Core
{
    public class SearchArgs<T> where T : class
    {
        public T Model { get; set; }
        public string Keyword { get; set; }
        public bool Pagination { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public List<SearchCondition> CustomConditions { get; set; }

        public List<OrderCondition> OrderConditions { get; set; }

        public SearchArgs()
        {
            Pagination = true;
            PageIndex = 1;
            PageSize = 50;
        }
    }
}
