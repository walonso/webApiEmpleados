using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecursosHumanos2.Repositorio
{
    public interface IRepositorio<T> where T : Entidad 
    {
        void Insertar(T entidad);
        void Actualizar(T entidad);
        void Borrar(int id);
        dynamic Obtener(T entidad);
    }
}
