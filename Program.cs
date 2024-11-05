using Microsoft.Identity.Client;
using Spectre.Console;
using System.Globalization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CRUD_de_Personas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string opcion,nombre,apellido;
            int id;
            CPersona Persona;
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
                        table.Title("[red] Lista de Persona de la Base de Datos[/]");
                        table.AddColumn("[yellow]ID[/]");
                        table.AddColumn("[blue]Nombre[/]");
                        table.AddColumn("[blue]Apellido[/]");
                        
                        List<CPersona> list = CPersonaAccesoDatos.Leer();
                        foreach (CPersona persona in list)
                        {
                            table.AddRow(persona.Id.ToString(), persona.Nombre, persona.Apellido);
                        }
                        AnsiConsole.Render(table);
                        Console.ReadLine();
                        break;
                    case "Agregar Una Nueva Persona":
                        Console.Clear();

                        AnsiConsole.WriteLine("Ingrese los Datos de La [green] Persona a agregar[/]");

                        nombre= AnsiConsole.Prompt<string>(new TextPrompt<string>("Ingrese el [darkturquoise] Nombre [/]"));
                        apellido= AnsiConsole.Prompt<string>(new TextPrompt<string>("Ingrese Apellido de La [darkturquoise] Persona a agregar[/]"));
                        Persona= new CPersona(nombre, apellido);

                        CPersonaAccesoDatos.Guardar(Persona);
                        break;
                    case "Eliminar Una Persona":

                        Console.Clear();

                        AnsiConsole.WriteLine("Ingrese El  ID de La  Persona  a Sacar de la  Base de Datos ");

                        id = int.Parse( AnsiConsole.Prompt<string>(new TextPrompt<string>("Ingrese el [Red] ID [/]")));

                        try
                        {
                            CPersonaAccesoDatos.EliminarPersonaID(id);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                }

            } while (opcion != "Salir");

            


        }
    }
}
