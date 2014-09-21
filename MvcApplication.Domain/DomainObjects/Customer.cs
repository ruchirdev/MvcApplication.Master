using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcApplication.Domain.DomainObjects
{
    public class Customer
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(250)]
        public string Firstname { get; set; }

        [Required]
        [StringLength(250)]
        public string Lastname { get; set; }

        [Required]
        [StringLength(320)]
        public string Email { get; set; }

        [Required]
        public int Status { get; set; }

    }
}
