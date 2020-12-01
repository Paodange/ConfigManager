using System;

namespace Mgi.Framework.Core.ApiContract
{
    public class BusinessException : Exception
    {
        public AppCode ResponseCode { get; set; }
        public BusinessException(AppCode responseCode) : base(responseCode.ToString())
        {
            ResponseCode = responseCode;
        }
    }
}
