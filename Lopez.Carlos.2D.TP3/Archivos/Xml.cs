using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    public class Xml<T>: IArchivo<T>
    {
        /// <summary>
        /// Implementación del método Guardar para guardar un archivo XML
        /// </summary>
        /// <param name="archivo">String que representa el nombre y ruta del archivo a guardar</param>
        /// <param name="datos">String para recibir los datos a guardar</param>
        /// <returns>booleano de control de ejecución true si guardo ok false si hubo error</returns>
        public bool Guardar(string archivo, T datos)
        {
            XmlSerializer serializador = new XmlSerializer(typeof(T));
            XmlTextWriter escritor = null;
            bool retValue = false;

            try
            {
                escritor = new XmlTextWriter(archivo, Encoding.UTF8);
                serializador.Serialize(escritor, datos);
                retValue = true;
            }
            catch (Exception)
            {

                throw new ArchivosException();
            }
            finally
            {
                escritor.Close();
            }
            return retValue;
        }
        /// <summary>
        /// Implementación del método Guardar para guardar un archivo XML
        /// </summary>
        /// <param name="archivo">String que representa el nombre y ruta del archivo a guardar</param>
        /// <param name="datos">String para recibir los datos a guardar</param>
        /// <returns>booleano de control de ejecución true si guardo ok false si hubo error</returns>
        public bool Leer(string archivo, out T datos)
        {
            XmlSerializer serializador = new XmlSerializer(typeof(T));
            XmlTextReader lector = null;
            bool retValue = false;

            try
            {
                lector = new XmlTextReader(archivo);
                datos = (T)serializador.Deserialize(lector);
                retValue = true;

            }
            catch (Exception)
            {

                throw new ArchivosException();
            }
            finally
            {
                lector.Close();
            }
            return retValue;
        }
    }
}
