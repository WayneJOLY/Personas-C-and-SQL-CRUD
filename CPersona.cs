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
        uint id;

        public CPersona(string nombre, string apellido)
        {
           
            this.nombre = nombre;
            this.apellido = apellido;
        }
        public CPersona(uint id,string nombre, string apellido)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellido = apellido;
        }

        public string Nombre {  get { return nombre; } set { this.nombre = value; } }
        public string Apellido { get { return apellido; } set {  apellido = value; } }
        public uint Id { get { return id; } set { id = value; } }   
        public override string ToString()
        {
            return $"{id} \b {nombre} \t\t {apellido}\n";
        }
    }
}
