using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSVenta.Models.Response;
using WSVenta.Models.ViewModels;
using WSVenta.services;

namespace WSVenta.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class UserController : Controller
    {

        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public IActionResult Autentificar([FromBody] AuthRequest model)
        {
            Respuesta respuesta = new Respuesta();
            var userresponse = _userService.Auth(model);

            if (userresponse == null) {
                //Manda error barRquest enfocado a la uthentificacion
                respuesta.Exito = 0;
                respuesta.Mensaje = "Usuario o contrasenia incorrecta";
                return BadRequest(respuesta);
        }
            respuesta.Exito = 1;
            respuesta.Data = userresponse;
            return Ok(respuesta);
        }
    }
}
