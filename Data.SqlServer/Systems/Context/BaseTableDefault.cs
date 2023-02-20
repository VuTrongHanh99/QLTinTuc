using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.SqlServer.Data
{
    public class BaseTableDefault
    {
        //Sắp xếp
        [Column("order", Order = 100)]
        public int Order { get; set; } = 0;
        //Trạng thái Ẩn hiện
        [Column("status", Order = 101)]
        public bool Status { get; set; } = true;
        //Sự mô tả
        [Column("description", Order = 102)]
        public string Description { get; set; } = string.Empty;
        //Ngày tạo
        [Column("created_date", Order = 103)]
        public DateTime? CreatedDate { get; set; } = DateTime.Now;

        //[Column("created_user_id", Order = 104)]
        //public int? CreatedUserId { get; set; } = UserConstants.AdministratorId;

        [Column("modified_date", Order = 105)]
        public DateTime? ModifiedDate { get; set; }

        //[Column("modified_user_id", Order = 106)]
        //public int? ModifiedUserId { get; set; }
    }
}
