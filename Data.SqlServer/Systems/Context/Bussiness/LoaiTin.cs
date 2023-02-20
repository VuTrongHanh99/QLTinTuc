using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.SqlServer.Data
{
    [Table("LoaiTin")]
    public class LoaiTin : BaseTableDefault
    {
        [Key]
        [Column("type_id")]
        public int TypeId { get; set; }

        [StringLength(128)]
        [Column("type_name")]
        public string TypeName { get; set; } = string.Empty;


        [ForeignKey("TheLoai")]
        [Column("category_id")]
        public int CategoryId { get; set; }

        public TheLoai TheLoai { get; set; }
    }
}
