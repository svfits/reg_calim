using System;
using System.ComponentModel.DataAnnotations;

namespace reg_claim4.Models
{
    public class logs
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string events { get; set; }
        public DateTime dataTime { get; set; }
        public string pc_ip { get; set; }
        public string pc_name { get; set; }
        public string Url { get; set; }
    }
}
