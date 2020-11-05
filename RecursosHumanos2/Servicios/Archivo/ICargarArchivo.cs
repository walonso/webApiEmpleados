using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecursosHumanos2.Servicios.Archivo
{
    public interface ICargarArchivo
    {
        IEnumerable<T> ObtenerDatos<T>(string archivo);
    }
}
