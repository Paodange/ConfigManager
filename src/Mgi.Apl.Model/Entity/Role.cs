using System.ComponentModel.DataAnnotations.Schema;

namespace Mgi.Apl.Model.Entity
{
    [Table("sys_role")]
    public class Role : EditableModel<int?>
    {
        [Column("name")]
        public string Name { get; set; }
        [Column("description")]
        public string Description { get; set; }
    }
}
//name varchar 100	0	-1			pg_catalog	default	0	0	0	0
//description varchar 255	0	-1			pg_catalog	default	0	0	0	0
