using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Mgi.Framework.Util
{
    public class MD5Util
    {
        public static string MD5Stream(string filePath)
        {
            using (FileStream stream = File.Open(filePath, FileMode.Open))
            {
                return MD5Stream(stream);
            }
        }

        public static string MD5Stream(Stream stream)
        {
            using (var md5 = new MD5CryptoServiceProvider())
            {
                var data = md5.ComputeHash(stream);
                StringBuilder sb = new StringBuilder(32);
                for (int i = 0; i < data.Length; i++)
                {
                    sb.Append(data[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}
