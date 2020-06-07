using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebClientWASM.infrastructure
{
    public class OrderFormModel
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
        [Required]
        [Range(1, 10000)]
        public int Qty { get; set; } = 1;
    }
}
