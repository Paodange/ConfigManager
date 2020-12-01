using System.ComponentModel.DataAnnotations.Schema;

namespace Mgi.Apl.Model.Entity
{
    [Table("sys_lookup")]
    public class Lookup : EditableModel<int?>
    {
        [Column("look_up_code")]
        public string LookUpCode { get; set; }
        [Column("code")]
        public string Code { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("desc")]
        public string Desc { get; set; }
        [Column("sort")]
        public int? Sort { get; set; }
    }
}
//look_up_code varchar 255	0	0			pg_catalog	default	0	0	0	0
//code varchar 255	0	-1					0	0	0	0
//name varchar 255	0	-1			pg_catalog	default	0	0	0	0
//sort int4    32	0	-1					0	0	0	0
