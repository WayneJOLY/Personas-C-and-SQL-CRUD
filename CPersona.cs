using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_de_Personas
{
    public  class CPersona
    {
        string nombre;
        string apellido;

        public CPersona(string nombre, string apellido)
        {
            this.nombre = nombre;
            this.apellido = apellido;
        }


        public string Nombre {  get { return nombre; } set { this.nombre = value; } }
        public string Apellido { get { return apellido; } set {  apellido = value; } }

        public override string ToString()
        {
            return $" Nombre :{nombre} \t\t Apellido :{apellido}";
        }
    }
}
