using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Empleado : Persona
    {
        #region Propiedades
        private int empleadoId;
        string usuario;
        string clave;

        public int idEmpleado
        {
            get { return empleadoId; }
        }

        public override int Dni
        {
            get { return this.dni; }
        }

        public override string Nombre
        {
            get { return this.nombre; }
        }

        public override string Apellido
        {
            get { return this.apellido; }
        }

        public string Usuario
        {
            get { return usuario; }
        }

        public string Clave
        {
            get { return usuario; }
        }
        #endregion


        #region Constructores
        public Empleado(string nombre, string apellido, int dni, string usuario, string claveAcceso, int idEmpleado) : base(nombre, apellido, dni)
        {
            this.usuario = usuario;
            this.clave = claveAcceso;
            this.empleadoId = idEmpleado;
        }
        #endregion

        #region Sobrecarga de Operadores
        /// <summary>
        /// Sobrecarga del operador == para validar si dos objetos de tipo Empleado son iguales a partir del atributo Id
        /// </summary>
        /// <param name="unCliente"></param>
        /// <param name="otroCliente"></param>
        /// <returns></returns>
        public static bool operator ==(Empleado otroEmpleado, Empleado unEmpleado)
        {
            bool retValue = false;
            // for (int i = 0; i < listaEmpleados.Count; i++)
            // {
            if (otroEmpleado.idEmpleado == unEmpleado.idEmpleado)
            {
                retValue = true;
            }
            //  }
            return retValue;
        }

        /// <summary>
        /// Sobrecarga del operador != para validar si dos objetos de tipo Empleado NO son iguales a partir del atributo Id
        /// </summary>
        /// <param name="unCliente"></param>
        /// <param name="otroCliente"></param>
        /// <returns></returns>
        public static bool operator !=(Empleado otroEmpleado, Empleado unEmpleado)
        {
            return !(otroEmpleado == unEmpleado);
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Método que sobreescribe el método virtual Mostrar de la Clase Persona y devuelve los datos del empleado
        /// </summary>
        /// <returns>string con los datos del cliente</returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.Mostrar());
            sb.AppendLine(idEmpleado.ToString());

            return sb.ToString();
        }
        #endregion
    }
}

