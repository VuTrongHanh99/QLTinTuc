using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.SqlServer.Data
{
    [Table("TheLoai")]
    public class TheLoai : BaseTableDefault
    {
        [Key]
        [Column("category_id")]
        public int CategoryId { get; set; }

        [StringLength(128)]
        [Column("category_name")]
        public string CategoryName { get; set; } = String.Empty;
    }
}
