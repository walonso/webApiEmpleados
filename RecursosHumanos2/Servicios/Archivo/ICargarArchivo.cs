using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RecursosHumanos2.Servicios.Archivo
{
    public interface ICargarArchivo
    {
        IEnumerable<T> ObtenerDatos<T>(StreamReader archivo);
    }
}
