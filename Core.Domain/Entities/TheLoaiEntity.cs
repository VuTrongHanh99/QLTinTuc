using Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Entities
{
    public class TheLoaiEntity : BaseEntity
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = String.Empty;
    }
}
