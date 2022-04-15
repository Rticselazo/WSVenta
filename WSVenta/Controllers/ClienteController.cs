using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSVenta.Models;
using WSVenta.Models.Response;
using WSVenta.Models.ViewModels;

namespace WSVenta.Controllers
{
    [Route("ruta/[controller]")]
    [ApiController]
    //Autorizacion previo haber sido registrado en startup para el servicio, Necesita del token en POST para poder recibir los datos NO CONFUNDIR CON ENCRIPTADO SHA256
    [Authorize]
    public class ClienteController : ControllerBase
    {
        
        [HttpGet]
        public IActionResult Get()
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {

                using (VentaRealContext db = new VentaRealContext())
                {
                    //Define la variable con solo igualarlo con un numero o un texto
                    //var lst = 1;
                    var lst = db.Cliente.OrderByDescending(d=>d.Id).ToList();

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

        [HttpPost]
        
        public IActionResult Add(ClienteRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
          

            try
            {
                using (VentaRealContext db = new VentaRealContext())
                {
                    Cliente cliente = new Cliente();
                    cliente.Nombre = oModel.Nombre;
                    db.Cliente.Add(cliente);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;

                }

                    
            }
            catch ( Exception e)
            {
                oRespuesta.Mensaje = e.Message;
            }


            return Ok(oRespuesta);

        }

        [HttpPut]

        public IActionResult Edit(ClienteRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();


            try
            {
                using (VentaRealContext db = new VentaRealContext())
                {
                    Cliente cliente = db.Cliente.Find(oModel.id);
                    cliente.Nombre = oModel.Nombre;
                    db.Entry(cliente).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    oRespuesta.Exito = 1;

                }


            }
            catch (Exception e)
            {
                oRespuesta.Mensaje = e.Message;
            }


            return Ok(oRespuesta);

        }

        //Si se desea que retorne en el URL indicarlo
        [HttpDelete("{Id}")]

        public IActionResult Delete(int Id)
        {
            Respuesta oRespuesta = new Respuesta();


            try
            {
                using (VentaRealContext db = new VentaRealContext())
                {
                    Cliente cliente = db.Cliente.Find(Id);
                    db.Remove(cliente);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;

                }


            }
            catch (Exception e)
            {
                oRespuesta.Mensaje = e.Message;
            }


            return Ok(oRespuesta);

        }

        
    }

}
