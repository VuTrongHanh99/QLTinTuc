using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.SqlServer.Data
{
    [Table("CacViTri")]
    public class CacViTri
    {
        [Key]
        [Column("vitri_id")]
        public int ViTriId { get; set; }

        [StringLength(128)]
        [Column("vitri_name")]
        public string ViTriName { get; set; }= String.Empty;
    }
}
