using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using MicroOrm.Dapper.Repositories.Attributes;

namespace Mgi.Apl.Model.Entity
{
    [Table("material")]
    public class Material : EditableModel<int?>
    {
        [Column("status")]
        public int? Status { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("short_name")]
        public string ShortName { get; set; }
        [Column("category_id")]
        [IgnoreUpdate]
        public int? CategoryId { get; set; }
        [Column("category_code")]
        [IgnoreUpdate]
        public string CategoryCode { get; set; }
        [Column("type_id")]
        [IgnoreUpdate]
        public int? TypeId { get; set; }
        [Column("type_name")]
        [IgnoreUpdate]
        public string TypeName { get; set; }
        [Column("brand_id")]
        [IgnoreUpdate]
        public int? BrandId { get; set; }
        [Column("brand_name")]
        [IgnoreUpdate]
        public string BrandName { get; set; }
        [Column("desc")]
        public string Desc { get; set; }
        [Column("part_number")]
        [IgnoreUpdate]
        public string PartNumber { get; set; }
        [Column("detail")]
        public string Detail { get; set; }
        [Column("container_material_id")]
        public int? ContainerMaterialId { get; set; }
        [Column("container_part_number")]
        public string ContainerPartNumber { get; set; }
        /// <summary>
        /// 适用料架id
        /// </summary>
        [Column("rack_id")]
        public int? RackId { get; set; }
        /// <summary>
        /// 适用料架的PN
        /// </summary>
        [Column("rack_pn")]
        public string RackPn { get; set; }
    }
}
//status int4    32	0	-1					0	0	0	0
//name varchar 255	0	-1			pg_catalog	default	0	0	0	0
//short_name varchar 255	0	-1			pg_catalog	default	0	0	0	0
//category_id int4    32	0	-1					0	0	0	0
//category_name varchar 255	0	-1			pg_catalog	default	0	0	0	0
//brand_id int4    32	0	-1					0	0	0	0
//brand_name varchar 255	0	-1			pg_catalog	default	0	0	0	0
