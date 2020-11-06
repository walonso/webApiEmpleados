using RecursosHumanos2.Repositorio;
using RecursosHumanos2.Repositorio.Entidades;
using RecursosHumanos2.Servicios.Archivo;
using RecursosHumanos2.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RecursosHumanos2.Servicios
{
    public class BulkService : IBulkService
    {
        private IRepositorio<Empleado> _repositorio;

        public BulkService(IRepositorio<Empleado> repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task Cargar(StreamReader archivoStream, string archivo)
        {
            FabricaArchivo fabrica = new FabricaArchivo();
            ICargarArchivo manejador = fabrica.ObtenerManejadorCargaArchivo(archivo);
            IEnumerable<Empleado> empleados = manejador.ObtenerDatos<Empleado>(archivoStream);

            await Task.Run(() => CargarLista(empleados));
        }

        private void CargarLista(IEnumerable<Empleado> empleados)
        {
            foreach (Empleado empleado in empleados)
            {
                _repositorio.Insertar(empleado);
            }
        }
    }
}
