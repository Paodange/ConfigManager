using System.ComponentModel.DataAnnotations.Schema;

namespace Mgi.Apl.Model.Entity
{
    [Table("material_serial_no")]
    public class MaterialSerialNo : AbstractModel<int?>
    {
        [Column("brand_code")]
        public string BrandCode { get; set; }
        [Column("type_code")]
        public string TypeCode { get; set; }
        [Column("serial_no")]
        public int SerialNo { get; set; }
    }
}
//brand_code varchar 255	0	-1			pg_catalog	default	0	0	0	0
//type_code varchar 255	0	-1			pg_catalog	default	0	0	0	0
//serial_no int4    32	0	-1					0	0	0	0
