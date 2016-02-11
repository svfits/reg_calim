using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reg_claim4.Models
{
    public class Ad_users
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public string role { get; set; }
        public List<Groups> group { get; set; }
        public virtual List<Groups> Groups { get; set; }
    }
    public class Groups
    {       
        public int Id { get; set; }        
        public string UserName { get; set; }
        public string NameGroups { get; set; }
        public virtual Ad_users Ad_users { get; set; }
    }
}
