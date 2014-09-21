using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcApplication.Dto
{
    public class CustomerViewModel
    {
        public Guid Id { get; set; }

        [Display(Name="Firstname")]
        [Required(ErrorMessage="Firstname is required")]
        [RegularExpression(@"[A-Za-z0-9 ,?.&\/ \-\'() ]*", ErrorMessage = "Firstname is not valid")]
        public string Firstname { get; set; }

        [Display(Name = "Lastname")]
        [Required(ErrorMessage = "Lastname is required")]
        [RegularExpression(@"[A-Za-z0-9 ,?.&\/ \-\'() ]*", ErrorMessage = "Lastname is not valid")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Email is not valid")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        public int Status { get; set; }
    }
}
