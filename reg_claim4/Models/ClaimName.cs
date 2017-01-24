using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reg_claim4.Models
{
    public class ClaimeName
    {
    [Key]
    public int Id { get; set; }
    public string claimName { get; set; }
    public int dataEndClaim { get; set; }
}
}
