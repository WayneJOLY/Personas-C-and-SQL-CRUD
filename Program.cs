using Spectre.Console;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CRUD_de_Personas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string opcion;
            CInterfaz interfaz = new CInterfaz();

           interfaz.Menu();

            //Console.Write(opcion);

            do
            {

                opcion = interfaz.Menu();

                switch(opcion)
                {
                    case "Mostar la Lista de Personas":

                        var table = new Table();
                        table.AddColumn("ID");
                        table.AddColumn("Nombre");
                        table.AddColumn("Apellido");
                        List<CPersona> list = CPersonaAccesoDatos.Leer();
                        foreach (CPersona persona in list)
                        {
                            table.AddRow(persona.Id.ToString(), persona.Nombre, persona.Apellido);
                        }
                        AnsiConsole.Render(table);
                        break;
                    case "Agregar Una Nueva Persona":
                        break;
                    case "Eliminar Una Persona":
                        break;
                }

            } while (opcion != "Salir");

            


        }
    }
}
