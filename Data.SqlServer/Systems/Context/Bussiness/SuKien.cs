using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.SqlServer.Data
{
    [Table("SuKien")]
    public class SuKien : BaseTableDefault
    {
        [Key]
        [Column("event_id")]
        public int EventId { get; set; }

        [StringLength(128)]
        [Column("event_title")]
        public string EventName { get; set; } =String.Empty;

        [Column("event_date")]
        public DateTime? EventDate { get; set; }

        [StringLength(128)]
        [Column("event_image")]
        public string EventImageUrl { get; set; } = String.Empty;
    }
}
