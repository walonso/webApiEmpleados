using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecursosHumanos2.Repositorio.Entidades;
using RecursosHumanos2.Servicios.Interfaces;
using System;

namespace RecursosHumanos2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private IEmpleadoService _empleadoService;

        public EmpleadoController(IEmpleadoService empleadoService)
        {
            _empleadoService = empleadoService;
        }

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public IActionResult Get()
        {
            return Ok(_empleadoService.ObtenerTodo());
            //[HttpGet("asyncsale")]
            //public async IAsyncEnumerable<Product> GetOnSaleProductsAsync()
            //{
            //    var products = _repository.GetProductsAsync();

            //    await foreach (var product in products)
            //    {
            //        if (product.IsOnSale)
            //        {
            //            yield return product;
            //        }
            //    }
            //}
        }
        public HttpResponse put(Empleado empleado)
        {
            throw new NotImplementedException();
        }
        public HttpResponse post(Empleado empleado)
        {
            throw new NotImplementedException();
        }

        public HttpResponse Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
