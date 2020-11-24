using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// Método que Serializa datos y los guarda en un archivo de tipo XLM
        /// </summary>
        /// <param name="archivo">ruta del archivo a guardar</param>
        /// <param name="datos">parámetro genérico con los datos a guardar</param>
        /// <returns></returns>
        public bool Guardar(string archivo, T datos)
        {
            try
            {
                if (archivo != null)
                {
                    using (XmlTextWriter writer = new XmlTextWriter(archivo, Encoding.UTF8))
                    {
                        XmlSerializer ser = new XmlSerializer(typeof(T));

                        ser.Serialize(writer, datos);

                        return true;
                    }
                }
            }
            catch (Exception e)
            {

                throw new ArchivosException("Error al intentar guardar archivo xml", e);
            }

            return false;
        }

        /// <summary>
        /// Método que lee de un archivo en formato XLM
        /// </summary>
        /// <param name="archivo">archivo a leer</param>
        /// <param name="datos">datos a guardar en el archivo xlm (parámetro generico)</param>
        /// <returns></returns>
        public bool Leer(string archivo, out T datos)
        {
            datos = default(T);

            try
            {
                if (File.Exists(archivo))
                {
                    using (XmlTextReader reader = new XmlTextReader(archivo))
                    {
                        XmlSerializer ser = new XmlSerializer(typeof(T));

                        datos = (T)ser.Deserialize(reader);

                        return true;
                    }
                }
            }
            catch (Exception)
            {

                throw new ArchivosException("Error al intentar leer archivo xml");
            }

            return false;
        }
    }
}
