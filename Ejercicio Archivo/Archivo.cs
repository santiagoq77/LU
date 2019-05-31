using System;
using System.IO;
using System.Collections.Generic;

namespace Ejercicio_Archivo
{
    public class Archivo
    {
        public void escribirArchivo(List<Contacto> lista)
        {
            if(File.Exists(@"C:\Users\Santiago\Desktop\Lagash\Ejercicio Archivo\Ejercicio.txt"))
            {
                StreamWriter txt = new StreamWriter(@"C:\Users\Santiago\Desktop\Lagash\Ejercicio Archivo\Ejercicio.txt");
                foreach(var person in lista)
                {
                    txt.WriteLine(person.Nombre + '\t' + person.Telefono);
                }
            }
        }
        public string leerArchivo()
        {
            if(File.Exists(@"C:\Users\Santiago\Desktop\Lagash\Ejercicio Archivo\Ejercicio.txt"))
            {
            StreamReader txt = new StreamReader(@"C:\Users\Santiago\Desktop\Lagash\Ejercicio Archivo\Ejercicio.txt");

            string lectura = txt.ReadToEnd();
            txt.Close();

            return lectura;
            }
            return null;
        }
    }
}