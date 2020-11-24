using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using System.Xml;
using Archivos;

namespace ClasesInstanciables
{
    public class Universidad
    {
        #region Atributos
        private List<Alumno> alumnos;
        private List<Profesor> profesores;
        private List<Jornada> jornada;
        #endregion

        #region Enumerado
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }
        #endregion

        #region Propiedades
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

        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores = value;
            }
        }

        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornada;
            }
            set
            {
                this.jornada = value;
            }
        }

        public Jornada this[int i]
        {
            get
            {
                return jornada[i];
            }
            set
            {
                jornada[i] = value;
            }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto del objeto Universidad
        /// </summary>
        public Universidad()
        {
            this.Jornadas = new List<Jornada>();
            this.Instructores = new List<Profesor>();
            this.Alumnos = new List<Alumno>();
        }
        #endregion

        #region Métodos

        /// <summary>
        /// Override del método ToString() para mostrar los datos un Universidad
        /// </summary>
        /// <returns>String que representa los datos de un Universidad</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(MostrarDatos(this));
            return sb.ToString();
        }

        /// <summary>
        /// Método que muestra los datos un objeto de tipo Universidad
        /// </summary>
        /// <param name="uni">Objeto de tipo Universidad</param>
        /// <returns>String que representa los datos de un Universidad</returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("JORNADA: ");
            foreach (Jornada unaJornada in uni.jornada)
            {
                sb.AppendLine(unaJornada.ToString());
            }
            return sb.ToString();
        }

        /// <summary>
        /// Método que guarda los datos de un Universidad en un archivo XML
        /// </summary>
        /// <param name="uni">Objeto de tipo Universidad</param>
        /// <returns>Booleano de control de ejecución true si guardo ok flase si hubo un error</returns>
        public static bool Guardar(Universidad uni)
        {
            bool retValue = false;
            Xml<Universidad> xml = new Xml<Universidad>();
            string rutaDeArchivo = String.Format("{0}\\Universidad.xml", Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            retValue = xml.Guardar(rutaDeArchivo, uni);
            return retValue;
        }

        /// <summary>
        /// Método que lee de una archivo xml los datos para armar un objeto de tipo Universidad
        /// </summary>
        /// <returns></returns>
        public static Universidad Leer()
        {
            Xml<Universidad> xml = new Xml<Universidad>();
            Universidad uni = new Universidad();
            string rutaDeArchivo = String.Format("{0}\\Universidad.xml", Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            xml.Leer(rutaDeArchivo, out uni);
            return uni;

        }
        #endregion

        #region Sobrecarga de Operadores
        /// <summary>
        /// Sobrecarga del operador == para saber si un alumno pertenece a la lista de alumnos de un Universidad
        /// </summary>
        /// <param name="g">Objeto de tipo Universidad</param>
        /// <param name="a">Objeto de tipo Alumno</param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            bool retValue = false;

            foreach (Alumno unAlumno in g.Alumnos)
            {
                if (unAlumno == a)
                {
                    retValue = true;
                }
            }

            return retValue;
        }

        /// <summary>
        /// Sobrecarga del operador != para saber si un alumno NO pertenece a la lista de alumnos de un Universidad
        /// </summary>
        /// <param name="g">Objeto de tipo Universidad</param>
        /// <param name="a">Objeto de tipo Alumno</param>
        /// <returns></returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }
        /// <summary>
        ///Sobrecarga del operador == para saber si un Profesor pertenece a la lista de un Universidad
        /// </summary>
        /// <param name="g">>Objeto de tipo Universidad</param>
        /// <param name="i">>Objeto de tipo Profesor</param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            bool retValue = false;

            foreach (Profesor unProfesor in g.Instructores)
            {
                if (unProfesor == i)
                {
                    retValue = true;
                }
            }

            return retValue;
        }
        /// <summary>
        /// Sobrecarga del operador != para saber si un Profesor NO pertenece a la lista de un Universidad
        /// </summary>
        /// <param name="g">>Objeto de tipo Universidad</param>
        /// <param name="i">Objeto de tipo Profesor></param>
        /// <returns></returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }
        /// <summary>
        /// Sobrecarga del operador == para saber si una clase tiene un instructor asignado
        /// </summary>
        /// <param name="g">>Objeto de tipo Universidad</param>
        /// <param name="clase">EClases que indica una clase</param>
        /// <returns></returns>
        public static Profesor operator ==(Universidad g, EClases clase)
        {

            foreach (Profesor unProfesor in g.Instructores)
            {
                if (unProfesor == clase)
                {
                    return unProfesor;
                }
            }
            throw new SinProfesorException();
        }
        /// <summary>
        /// Sobrecarga del operador != para saber si una clase NO tiene un instructor asignado
        /// </summary>
        /// <param name="g">>Objeto de tipo Universidad</param>
        /// <param name="clase">EClases que indica una clase</param>
        /// <returns></returns>
        public static Profesor operator !=(Universidad g, EClases clase)
        {
            foreach (Profesor unProfesor in g.Instructores)
            {
                if (unProfesor != clase)
                {
                    return unProfesor;
                }
            }
            throw new SinProfesorException();
        }
        /// <summary>
        /// Sobrecarga del operador + para asignar una clase a un Universidad
        /// </summary>
        /// <param name="g">>Objeto de tipo Universidad</param>
        /// <param name="clase">EClases que indica una clase a asignar</param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {

            Profesor auxProfesor = (g == clase);
            Jornada jornada = new Jornada(clase, auxProfesor);
            foreach (Alumno unAlumno in g.Alumnos)
            {
                if (unAlumno == clase)
                {
                    jornada.Alumnos.Add(unAlumno);
                }
            }
            g.Jornadas.Add(jornada);
            return g;
        }
        /// <summary>
        /// Sobrecarga del operador + para asignar un Alumno a un Universidad
        /// </summary>
        /// <param name="u">>Objeto de tipo Universidad</param>
        /// <param name="a">>Objeto de tipo Alumno</param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u != a)
            {
                u.Alumnos.Add(a);
                return u;
            }
            throw new AlumnoRepetidoException();
        }
        /// <summary>
        /// Sobrecarga del operador + para asignar un Profesor a un Universidad
        /// </summary>
        /// <param name="u">>Objeto de tipo Universidad</param>
        /// <param name="i">>Objeto de tipo Profesor</param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (u != i)
            {
                u.Instructores.Add(i);
            }
            return u;
        }
        #endregion
    }
}
