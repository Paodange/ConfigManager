namespace Mgi.Framework.Core.Orm.Extensions
{
    public static class ObjectExtentions
    {
        public static bool IsNullOrEmptyString(this object obj)
        {
            if (obj == null) return true;
            if (obj is string)
            {
                return string.IsNullOrWhiteSpace((string)obj);
            }
            return false;
        }
    }
}
