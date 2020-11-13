using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RecursosHumanos2.Servicios.Archivo
{
    public class FabricaArchivo
    {
        public ICargarArchivo ObtenerManejadorCargaArchivo(string archivo)
        {
            var extension = Path.GetExtension(archivo).ToLower();
            //Switch case incluido en C# 8
            ICargarArchivo manejadorArchivos = extension switch
            {
                ".csv" => new CSV(),
                _ => throw new NotSupportedException()
            };

            return manejadorArchivos;
        }
    }
}
