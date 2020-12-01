namespace Mgi.Apl.Model
{
    public abstract class AbstractBO<T, PK> where T : class, new()
    {
        public PK Id { get; set; }
    }
}