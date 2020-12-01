using Mgi.Apl.Service;
using Mgi.Framework.Core.ApiContract;
using System;
using System.Collections.Concurrent;

namespace Mgi.Apl.Web.Data
{
    public sealed class TokenManager
    {
        private static readonly ConcurrentDictionary<string, IUserIdentity> dic = new ConcurrentDictionary<string, IUserIdentity>();

        public static IUserIdentity GetIdentity(string token)
        {
            bool success = dic.TryGetValue(token, out IUserIdentity userIdentity);
            return success ? userIdentity : null;
        }
        public static void SetIdentity(string token, IUserIdentity userIdentity)
        {
            dic.AddOrUpdate(token, userIdentity, (k, v) => userIdentity);
        }
        public static string NewToken(IUserIdentity userIdentity)
        {
            if (userIdentity == null)
            {
                throw new ArgumentNullException(nameof(userIdentity), "userIdentity cannot be null");
            }
            var token = Guid.NewGuid().ToString("N");
            SetIdentity(token, userIdentity);
            return token;
        }
        public static void RemoveToken(string token)
        {
            dic.TryRemove(token, out IUserIdentity userIdentity);
        }
    }
}
