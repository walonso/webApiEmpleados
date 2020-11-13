using RecursosHumanos2.Repositorio;
using RecursosHumanos2.Repositorio.Entidades;
using RecursosHumanos2.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecursosHumanos2.Servicios
{
    public class EmpleadoService : IEmpleadoService
    {
        private IRepositorio<Empleado> _repositorio;

        public EmpleadoService(IRepositorio<Empleado> repositorio)
        {
            _repositorio = repositorio;
        }

        public List<Empleado> ObtenerTodo()
        {
            List<Empleado> empleados = _repositorio.Obtener();
            return empleados;
        }

        public void Crear()
        {
            throw new NotImplementedException();
        }

        public void ActualizarPorId()
        {
            throw new NotImplementedException();
        }
        public void BorrarPorId()
        {
            throw new NotImplementedException();
        }
    }
}
