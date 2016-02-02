using System;
using System.ComponentModel.DataAnnotations;

namespace reg_claim4.Models
{
    public class claim
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string ClaimeName { get; set; }
        public string claimBody { get; set; }
        public DateTime dataTime { get; set; }
    }
}
