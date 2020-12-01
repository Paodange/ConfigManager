using Mgi.Framework.Core.ApiContract;

namespace Mgi.Apl.Service
{
    public class ResponseCode : AppCode
    {


        public ResponseCode(int code, string message) : base(code, message)
        {

        }

        /// <summary>
        /// 格式化Message 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public ResponseCode Format(params object[] args)
        {
            return new ResponseCode(Code, string.Format(Message, args));
        }


        #region 统一错误码定义
        public static readonly ResponseCode LoginValidateFailed = new ResponseCode(1001, "Username or password wrong");


        public static readonly ResponseCode ModelValidateError = new ResponseCode(501, "{0}");
        public static readonly ResponseCode MaterialCountOverLimit = new ResponseCode(550, "There can be 99 material under the same brand and type at most");
        public static readonly ResponseCode CannotFindMaterialById = new ResponseCode(551, "Cannot find Container Material with Id: {0}");
        public static readonly ResponseCode PartNumberCannotBeNull = new ResponseCode(552, "PartNumber connot be null");
        public static readonly ResponseCode PartNumberAlreadyExists = new ResponseCode(553, "PartNumber：{0} already exists");
        public static readonly ResponseCode InvalidCode = new ResponseCode(560, "Invalid Code");
        public static readonly ResponseCode CodeAlreadyExists = new ResponseCode(561, "Code {0} Already Exist");
        public static readonly ResponseCode DuplicateKeyFoundInConfigs = new ResponseCode(562, "There is duplicate config key in your configs");
        public static readonly ResponseCode ScriptMustContainScriptFile = new ResponseCode(580, "Script must contains a script file");
        public static readonly ResponseCode ScriptFileNotExists = new ResponseCode(581, "Script file not exists");
        public static readonly ResponseCode MaterialBrandHasBeenUsed = new ResponseCode(582, "Cannot delete material brand because it has been used");
        public static readonly ResponseCode MaterialCategoryHasBeenUsed = new ResponseCode(583, "Cannot delete material category because it has been used");
        public static readonly ResponseCode MaterialTypeHasBeenUsed = new ResponseCode(584, "Cannot delete material type because it has been used");
        public static readonly ResponseCode MaterialCategoryNotExist = new ResponseCode(585, "Material category with id:{0} not exists");
        public static readonly ResponseCode CannotModifyRequireContainerOrManualPn = new ResponseCode(586, "Cannot modify RequireContainer or Manual Part Number or RequireRack because it has been used");
        #endregion
    }
}
