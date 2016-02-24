using System;
using System.ComponentModel.DataAnnotations;

namespace reg_claim4.Models
{
    public class claim
    {
        [Key]
        public int Id { get; set; }
        public string UserNameFrom { get; set; }
        public string UserNameWhom { get; set; }       
        public string ClaimeName { get; set; }
        public string claimBody { get; set; }
        public DateTime dataTimeOpen { get; set; }
        public DateTime dataTimeEnd { get; set; }
        public string evants { get; set; }
        public string parents { get; set; }
        public string category { get; set; }
    }
}
