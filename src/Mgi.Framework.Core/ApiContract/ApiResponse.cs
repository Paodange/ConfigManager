using Newtonsoft.Json;

namespace Mgi.Framework.Core.ApiContract
{
    public class ApiResponse<T>
    {
        [JsonProperty(Order = 0)]
        public int Code { get; set; } = -1;
        [JsonProperty(Order = 10)]
        public string Message { get; set; }
        [JsonProperty(Order = 20)]
        public T Data { get; set; }

        public ApiResponse(AppCode appCode, T data = default(T)) : this(appCode)
        {
            Data = data;
        }

        public ApiResponse(T data = default(T)) : this(AppCode.Ok, data)
        {
        }
        public ApiResponse(AppCode appCode)
        {
            Code = appCode.Code;
            Message = appCode.Message;
            Data = default(T);
        }

        public bool IsOK()
        {
            return Code == 200;
        }
    }

    public class ApiResponse : ApiResponse<object>
    {
        public ApiResponse(AppCode appCode) : this(appCode, null)
        {

        }
        public ApiResponse(AppCode appCode, object data)
        {
            Code = appCode.Code;
            Message = appCode.Message;
            Data = data;
        }
        public static implicit operator ApiResponse(AppCode appCode)
        {
            return new ApiResponse(appCode);
        }
    }
}
