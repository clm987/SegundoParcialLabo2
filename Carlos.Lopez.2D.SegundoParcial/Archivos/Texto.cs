using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;


namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// Implementación del método Guardar para guardar un archivo de Texto
        /// </summary>
        /// <param name="archivo">String que representa el nombre y ruta del archivo a guardar</param>
        /// <param name="datos">String para recibir los datos a guardar</param>
        /// <returns>Booleao de control de ejecución true si guardo ok false si hubo error</returns>
        public bool Guardar(string archivo, string datos)
        {
            StreamWriter escritor = null;
            try
            {
                escritor = new StreamWriter(archivo);
                escritor.Write(datos);
            }
            catch (Exception)
            {

                throw new ArchivosException();
            }
            finally
            {
                escritor.Close();
            }

            return true;
        }

        /// <summary>
        /// Implementación del método Leer para guardar un archivo de Texto
        /// </summary>
        /// <param name="archivo">String que representa el nombre y ruta del archivo a Leer</param>
        /// <param name="datos">String para recibir los datos a Leer</param>
        /// <returns></returns>
        public bool Leer(string archivo, out string datos)
        {
            StreamReader lector = null;
            datos = "";
            try
            {
                lector = new StreamReader(archivo);
                lector.ReadToEnd();
            }
            catch (Exception)
            {

                throw new ArchivosException();
            }
            finally
            {
                lector.Close();
            }

            return true;
        }
    }
}
