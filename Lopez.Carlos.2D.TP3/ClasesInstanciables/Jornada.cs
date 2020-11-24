using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClasesInstanciables.Universidad;
using Excepciones;
using Archivos;

namespace ClasesInstanciables
{
    public class Jornada
    {
        #region Atributos y Propiedades
        private List<Alumno> alumnos;
        private EClases clase;
        private Profesor instructor;

        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }
        public EClases Clases
        {
            get
            {
                return this.clase;
            }
            set
            {
                this.clase = value;
            }
        }
        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                this.instructor = value;
            }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto del objeto de tipo Jornada
        /// </summary>
        private Jornada()
        {
            this.Alumnos = new List<Alumno>();
        }
        /// <summary>
        /// Constructor con parámetros del objeto de tipo Jornada
        /// </summary>
        /// <param name="clase"></param>
        /// <param name="instructor"></param>
        public Jornada(EClases clase, Profesor instructor) : this()
        {
            this.Clases = clase;
            this.Instructor = instructor;
        }
        #endregion

        #region Métodos 
        /// <summary>
        /// Sobrecarga del método ToString()
        /// </summary>
        /// <returns>String que representa datos de un objeto de tipo Jornada</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(String.Concat($"CLASE DE {this.Clases} POR {this.Instructor.ToString()}"));
            sb.AppendLine("ALUMNOS:");
            foreach (Alumno unAlumno in this.Alumnos)
            {
                sb.AppendLine(unAlumno.ToString());
            }
            sb.AppendLine("<---------------------------------------------------------------------------->");
            return sb.ToString();
        }
        /// <summary>
        /// Método que guarda un archivo de tipo .txt con los datos del objeto
        /// </summary>
        /// <param name="jornada">Objeto de tipo Jornada</param>
        /// <returns></returns>
        public static bool Guardar(Jornada jornada)
        {
            string rutaDeArchivo = String.Format("{0}\\jornada.txt", Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            Texto ArchivoDeTexto = new Texto();
            return ArchivoDeTexto.Guardar(rutaDeArchivo, jornada.ToString());
        }
        /// <summary>
        /// Método que lee un archivo de texto. 
        /// </summary>
        /// <returns>String que representa los datos cargados del texto</returns>
        public string Leer()
        {
            string rutaDeArchivo = String.Format("{0}\\jornada.txt", Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            Texto ArchivoDeTexto = new Texto();
            string datos = "";
            ArchivoDeTexto.Leer(rutaDeArchivo, out datos);
            return datos;
        }
        #endregion

        #region Sobrecarga de Operadores
        /// <summary>
        /// Sobrecarga del operador == para saber si un alumno pertenece a la lista de alumnos de una jornada
        /// </summary>
        /// <param name="j">Objeto de tipo Jornada</param>
        /// <param name="a">Objeto de tipo Alumno</param>
        /// <returns></returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            bool retValue = false;

            foreach (Alumno unAlumno in j.alumnos)
            {
                if (unAlumno == a)
                {
                    retValue = true;
                    break;
                }
            }

            return retValue;
        }
        /// <summary>
        /// Sobrecarga del operador != para saber si un alumno NO pertenece a la lista de alumnos de una jornada
        /// </summary>
        /// <param name="j">Objeto de tipo Jornada</param>
        /// <param name="a">Objeto de tipo Alumno</param>
        /// <returns></returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }
        /// <summary>
        /// Sobrecarga del operador + para agragar un alumno a la lista de alumnos de una jornada
        /// </summary>
        /// <param name="j">Objeto de tipo Jornada</param>
        /// <param name="a">Objeto de tipo Alumno</param>
        /// <returns></returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
            {
                j.alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }

            return j;
        }
        #endregion
    }
}
