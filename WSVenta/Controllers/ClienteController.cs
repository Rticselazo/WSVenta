using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSVenta.Models;
using WSVenta.Models.Response;

namespace WSVenta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Respuesta oRespuesta = new Respuesta();
            try { 
                    
                    using (VentaRealContext db =  new VentaRealContext())
                    {
                            //Define la variable con solo igualarlo con un numero o un texto
                            //var lst = 1;
                            var lst = db.Cliente.ToList();

                        //Indica si el proceso es exitoso y registra en la clase ReSPONSE/rESPUESTA
                        oRespuesta.Exito = 1;
                        oRespuesta.Data = lst;  
                    }
            }
            catch (Exception eX)
            {
                oRespuesta.Mensaje = eX.Message;
            }
            return Ok(oRespuesta);

        }

    }
}
