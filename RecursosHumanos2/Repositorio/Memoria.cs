using System;
using System.Collections.Generic;
using System.Linq;

namespace RecursosHumanos2.Repositorio
{
    public class Memoria<T> : IRepositorio<T> where T : Entidad 
    {
        public List<T> listaEnMemoria { get; set; }

        public Memoria()
        {
            listaEnMemoria = new List<T>();
        }

        public dynamic Obtener(T entidad)
        {
            var empleado = listaEnMemoria.FirstOrDefault(x => x.Id == entidad.Id);

            if (null == empleado)
            {
                throw new NullReferenceException("Entidad 'Empleado' no encontrada");
            }
            return empleado;
        }

        public void Actualizar(T entidad)
        {
            var empleado = listaEnMemoria.FirstOrDefault(x => x.Id == entidad.Id);

            if (null == empleado)
            {
                throw new NullReferenceException("Entidad 'Empleado' no existe");
            }

            listaEnMemoria.Remove(empleado);
            listaEnMemoria.Add(entidad);
        }

        public void Borrar(int id)
        {
            var empleado = listaEnMemoria.FirstOrDefault(x => x.Id == id);

            if (null == empleado)
            {
                throw new NullReferenceException("Entidad 'Empleado' no existe");
            }

            listaEnMemoria.Remove(empleado);
        }

        public void Insertar(T entidad)
        {

            var empleado = listaEnMemoria.FirstOrDefault(x => x.Id == entidad.Id);

            if (null != empleado)
            {
                throw new NullReferenceException("Entidad 'Empleado' ya existe");
            }

            listaEnMemoria.Add(entidad);
        }
    }
}
