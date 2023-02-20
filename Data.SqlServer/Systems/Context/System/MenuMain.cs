using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.SqlServer.Data
{
    [Table("MenuMain")]
    public class MenuMain :BaseTableDefault
    {
        [Key]
        [Column("menu_id")]
        public int MenuId { get; set; }

        [StringLength(128)]
        [Column("menu_name")]
        public string MenuName { get; set; } = String.Empty;

        [Column("parent_id")]
        public int ParentId { get; set; }

        [StringLength(128)]
        [Column("menu_url")]
        public string MenuUrl { get; set; } = String.Empty;
    }
}
