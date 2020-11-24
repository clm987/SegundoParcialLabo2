using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    /// <summary>
    /// Interface que recibe un parámetro generico a fin de definir métodos para leer y guardar archivos
    /// </summary>
    /// <typeparam name="T">parámetro genérico</typeparam>
    interface IArchivo<T>
    {
        /// <summary>
        /// Firma del método Guardar
        /// </summary>
        /// <param name="archivo">String que representa el nombre y ruta del archivo a guardar</param>
        /// <param name="datos">Tipo de dato Generico para recibir los datos a guardar</param>
        /// <returns></returns>
        bool Guardar(string archivo, T datos);
        /// <summary>
        /// Firma del método Leer
        /// </summary>
        /// <param name="archivo">String que representa el nombre y ruta del archivo a Leer</param>
        /// <param name="datos">Tipo de dato Generico para recibir los datos a Leer</param>
        /// <returns></returns>
        bool Leer(string archivo, out T datos);
    }
}
