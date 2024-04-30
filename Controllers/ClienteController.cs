using Microsoft.AspNetCore.Mvc;
using MY_APP_WEB_API.Controllers.Models;
using System.Collections.Generic;
using System.Linq;

namespace MY_APP_WEB_API.Controllers
{
    [ApiController]
    [Route("cliente")]
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        [Route("listar")]
   
        public ActionResult<IEnumerable<Persona>> listarCliente() 

        {
            var clientes = new List<Persona>
            {
                new Persona
                {
                    id = "1",
                    correo = "google@gmail.com",
                    edad = "22",
                    nombre = "Matias Bardales"
                },
                new Persona
                {
                    id = "2",
                    correo = "jean@gmail.com",
                    edad = "23",
                    nombre = "jean Bardales"
                }
            };
            return Ok(clientes);
        }

        [HttpGet]
        [Route("listarxid")]
        public ActionResult<Persona> listarClientexid(int codigo)
        {
            // Obtener el cliente de la base de datos según el código proporcionado
            var cliente = new Persona
            {
                id = codigo.ToString(),
                correo = "jean@gmail.com",
                edad = "23",
                nombre = "jean Bardales"
            };
            return Ok(cliente);
        }

        [HttpPost]
        [Route("guardar")]
        public ActionResult<dynamic> guardarCliente(Persona cliente)
        {
            cliente.id = "3";
            return Ok(new
            {
                success = true,
                message = "Cliente agregado",
                result = cliente
            });
        }

        [HttpPost]
        [Route("eliminar")]
        public ActionResult<dynamic> eliminarCliente(Persona cliente)
        {
            string token = Request.Headers["Authorization"].FirstOrDefault();

            // Eliminar el cliente de la base de datos
            if (token != "marco123.")
            {
                return BadRequest(); // Devuelve un HTTP 400 sin ningún contenido adicional
            }
            else
            {
                // Procede con la eliminación del cliente y devuelve una respuesta exitosa
                return Ok(new
                {
                    success = true,
                    message = "Cliente eliminado",
                    result = cliente
                });
            }
        }
    }
}
