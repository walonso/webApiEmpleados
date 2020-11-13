using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Http;
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
        public IEnumerable<T> ObtenerDatos<T>(StreamReader archivo)
        {
            IEnumerable<T> records;

            //using (var reader = new StreamReader(archivo.OpenReadStream()))
            //{                
                using (var csv = new CsvReader(archivo, CultureInfo.InvariantCulture))
                {
                csv.Configuration.Delimiter= ";";
                csv.Configuration.TrimOptions = TrimOptions.Trim;
                records = csv.GetRecords<T>().ToList();
                }
                //string line = String.Empty;
                //while ((line = reader.ReadLine()) != null)
                //{
                //    Console.WriteLine(line);
                //    line = reader.ReadLine();
                //    var particion = line.Split(";");
                //    Empleado empleado = new Empleado
                //    {
                //        Nombre = particion[0],
                //        Cargo = particion[1]
                //    };
                //    Console.WriteLine(empleado);
                //}
                ///*string contentAsString = reader.ReadToEnd();
                //byte[] bytes = new byte[contentAsString.Length * sizeof(char)];
                //System.Buffer.BlockCopy(contentAsString.ToCharArray(), 0, bytes, 0, bytes.Length);*/
            //}

            return records;
        }
    }
}
