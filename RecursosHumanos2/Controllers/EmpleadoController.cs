﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecursosHumanos2.Repositorio.Entidades;
using System;

namespace RecursosHumanos2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        public HttpResponse get()
        {
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
            throw new NotImplementedException();
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
