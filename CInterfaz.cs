using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_de_Personas
{
    public class CInterfaz
    {

        public string Menu()
        {
            Console.Clear();
            string opcion = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
        .Title("[green]Ingrese la Opcion elegida [/]?")
        .PageSize(10)
        .MoreChoicesText("[red](Usa las teclas de Direcion para elegir )[/]")
        .AddChoices(new[] {
            "Mostar la Lista de Personas","Agregar Una Nueva Persona","Eliminar Una Persona","Salir"
        }));
            
            
            return opcion;
        }

        
    }
}
