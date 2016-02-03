using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reg_claim4.Models
{
    public class category_claim
    {
    [Key]
    public int Id { get; set; }
    public string category { get; set; }
}
}
