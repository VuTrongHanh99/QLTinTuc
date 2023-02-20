using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Common
{
    public class BaseEntity
    {
        public int Order { get; set; } = 0;

        public bool Status { get; set; } = true;

        public string Description { get; set; } = string.Empty;

        public DateTime? CreatedDate { get; set; } = DateTime.Now;

        public DateTime? ModifiedDate { get; set; }
    }
}
