using System;
using System.IO;
using System.Collections.Generic;

namespace Ejercicio_Archivo

// Ejercicio: 
// Hacer un programa que escriba en un archivo de texto un listado de personas y teléfonos.
// El programa tiene que también poder leer el archivo y cargarlo en una colección
// Si modifico el archivo, tengo que poder leerlo nuevamente

{
    class Program
    {
        static void Main(string[] args)
            {   bool nosalgo = true;
                var agenda = new AgendaDeTomy();
                var arch = new Archivo();

                //agenda.cargaValoresPrevios();

                List<Contacto> lista = new List<Contacto>();
            
            while (nosalgo)
            {        
                Console.WriteLine("1) Ingresar nuevo contacto."); 
                Console.WriteLine("2) Actualizar archivo."); 
                Console.WriteLine("3) Mostrar agenda.");
                Console.WriteLine("4) Salir.");

            int menu = Console.Read();

                 switch(menu)
                {
                    case 1:
                    agenda.cargarLista(lista);
                    break;

                    case 2:
                    arch.escribirArchivo(lista);
                    break; 

                    case 3:
                    foreach (var lineas in lista)
                    {
                        Console.WriteLine(lineas);
                    }
                    break; 

                    case 4:
                    default: 
                    nosalgo = false;
                    break;       
                }
            }   
        }
    }
}