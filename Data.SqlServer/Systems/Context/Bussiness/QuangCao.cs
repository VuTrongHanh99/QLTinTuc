using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.SqlServer.Data
{
    [Table("QuangCao")]
    public class QuangCao
    {   
        [Key]
        [Column("quangcao_id")]
        public int QuangCaoId { get; set; }

        [StringLength(128)]
        [Column("quangcao_name")]
        public string QuangCaoName { get; set; } = String.Empty;

        [ForeignKey("LoaiTin")]
        [Column("type_id")]
        public int TypeId { get; set; }
        public LoaiTin LoaiTin { get; set; }    

        [ForeignKey("CacViTri")]
        [Column("vitri_id")]
        public int ViTriId { get; set; }
        public CacViTri CacViTri { get; set; }

        [StringLength(128)]
        [Column("qunagcao_image")]
        public string QuangCaoImageUrl { get; set; } = String.Empty;
    }
}
