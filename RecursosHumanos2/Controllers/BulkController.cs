using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecursosHumanos2.Servicios.Interfaces;

namespace RecursosHumanos2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BulkController : ControllerBase
    {
        private IBulkService _bulkService;

        public BulkController(IBulkService bulkService)
        {
            _bulkService = bulkService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(string archivo)
        {
            await _bulkService.Cargar(archivo);
            return Ok();
        }
    }
}
