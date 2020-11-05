using CsvHelper;
using RecursosHumanos2.Repositorio.Entidades;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RecursosHumanos2.Servicios.Archivo
{
    public class CSV : ICargarArchivo
    {
        public IEnumerable<T> ObtenerDatos<T>(string archivo)
        {
            IEnumerable<T> records ;
            using (var reader = new StreamReader(archivo))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                records = csv.GetRecords<T>();
            }
            return records;
        }
    }
}
