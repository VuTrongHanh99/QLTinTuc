using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.SqlServer.Data
{
    [Table("Tin")]
    public class Tin :BaseTableDefault
    {
        [Key]
        [Column("news_id")]
        public int QuangCaoId { get; set; }

        [StringLength(128)]
        [Column("news_title")]
        public string NewsTitle { get; set; } = String.Empty;

        [StringLength(128)]
        [Column("news_tomtat")]
        public string NewsTomTat { get; set; } = String.Empty;

        [StringLength(256)]
        [Column("news_content")]
        public string NewsContent { get; set; } = String.Empty;

        [StringLength(128)]
        [Column("news_image")]
        public string NewsImageUrl { get; set; } = String.Empty;

        [Column("news_soluot_xem")]
        public int SoLanXem { get; set; } = 100;


        [ForeignKey("LoaiTin")]
        [Column("type_id")]
        public int TypeId { get; set; }
        public LoaiTin LoaiTin { get; set; }

        [Column("bool_tinnoibat")]
        public bool TinNoiBat { get; set; } = true;

        [StringLength(128)]
        [Column("news_keyword")]
        public string NewsKeyWord { get; set; } = String.Empty;

    }
}
