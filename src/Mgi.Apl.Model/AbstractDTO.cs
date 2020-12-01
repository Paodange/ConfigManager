namespace Mgi.Apl.Model.DTO
{
    /// <summary>
    /// 数据库表实体基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="PK"></typeparam>
    public abstract class AbstractDTO<T, PK>
    {
        public PK Id { get; set; }
    }
}
