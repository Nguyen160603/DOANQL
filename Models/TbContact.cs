﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DOANQL.Models
{
    [Table("Tb_Contact")]
    public class TbContact
    {
        [Key]
        public int ContactId { get; set; }

        public string? Name { get; set; }

        public string? Email { get; set; } 

        public string? Phone { get; set; }
        public string? Subject { get; set; }

        public string? Message { get; set; }

        public int? IsRead { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string? ModifiedBy { get; set; }
    }
}
