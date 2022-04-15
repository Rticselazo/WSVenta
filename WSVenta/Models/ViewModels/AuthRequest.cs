using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WSVenta.Models.ViewModels
{
    public class AuthRequest
    {
        //  [Required] necesita de todos los datos para que funcione
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
