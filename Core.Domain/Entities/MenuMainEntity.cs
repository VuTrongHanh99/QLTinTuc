using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Entities
{
    public class MenuMainEntity
    {
        [Key]
        public int MenuId { get; set; }
        public string MenuName { get; set; } = String.Empty;
        public int ParentId { get; set; }=0;
        public string MenuUrl { get; set; } = String.Empty;
    }
    public class MenuMainSelect
    {
        public int MenuId { get; set; }
        public string MenuName { get; set; } = String.Empty;
    }
}
