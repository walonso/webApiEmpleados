using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RecursosHumanos2.Servicios.Interfaces
{
    public interface IBulkService
    {
        Task CargarAsync(StreamReader archivoStream, string archivo);
    }
}
