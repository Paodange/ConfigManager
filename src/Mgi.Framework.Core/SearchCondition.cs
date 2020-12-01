namespace Mgi.Framework.Core
{
    public class SearchCondition
    {
        /// <summary>
        /// 左括号数
        /// </summary>
        public int LeftBracket { get; set; }
        /// <summary>
        /// 右括号数
        /// </summary>
        public int RightBracket { get; set; }

        /// <summary>
        /// 字段名
        /// </summary>
        public string Field { get; set; }

        /// <summary>
        /// 比较类型
        /// </summary>
        public CompareType CompareType { get; set; }

        /// <summary>
        /// 比较值
        /// </summary>
        public object[] Values { get; set; }

        public SearchCondition()
        {

        }

        public SearchCondition(string field, CompareType compareType, params object[] values)
        {
            Field = field;
            CompareType = compareType;
            Values = values;
        }
    }
}
