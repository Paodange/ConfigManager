namespace Mgi.Framework.Core.ApiContract
{
    public class AppCode
    {
        public int Code { get; set; }
        public string Message { get; set; }
        /// <summary>
        /// 私有构造函数  避免到处定义错误码
        /// </summary>
        /// <param name="code"></param>
        /// <param name="message"></param>
        protected AppCode(int code, string message)
        {
            Code = code;
            Message = message;
        }

        public const int SUCCESS_CODE = 200;
        public bool IsOK()
        {
            return Code == SUCCESS_CODE;
        }


        public override string ToString()
        {
            return $"{Code}-{Message}";
        }

        #region 统一错误码定义
        public static readonly AppCode Ok = new AppCode(SUCCESS_CODE, "OK");
        public static readonly AppCode UnAuthorized = new AppCode(401, "UnAuthorized");
        public static readonly AppCode NotFound = new AppCode(404, "Not Found");
        public static readonly AppCode InternalServerError = new AppCode(500, "Internal Server Error");
        public static readonly AppCode UnSupport = new AppCode(501, "UnSupport Operation");
        #endregion
    }
}
