using RecursosHumanos2.Repositorio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecursosHumanos2.Servicios.Interfaces
{
    public interface IEmpleadoService
    {
        List<Empleado> ObtenerTodo();
    }
}
