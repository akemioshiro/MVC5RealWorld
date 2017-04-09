using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC5RealWorld.Models.ViewModel
{
    public class UserLoginView
    {
        [Key]
        public int SYSUserID { get; set; }
        [Required(ErrorMessage ="*")]
        [Display(Name ="Login ID")]
        public string LoginName { get; set; }
        [Required(ErrorMessage ="*")]
        [Display(Name ="Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
