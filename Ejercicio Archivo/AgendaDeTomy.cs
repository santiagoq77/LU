using System;
using System.IO;
using System.Collections.Generic;

namespace Ejercicio_Archivo
{
    public class AgendaDeTomy
    {
         List<Contacto> lista = new List<Contacto>();
         Archivo file = new Archivo();  
        public void cargaValoresPrevios()
        {
            string[] lineas = file.leerArchivo().Split(Environment.NewLine); 
            foreach (var line in lineas)
            {
                string[] campos = line.Split('\t');
                int longitud = campos.Length;
                //if (longitud > 1)
                lista.Add(new Contacto(campos[0],campos[1]));
            }
        }
        public void cargarLista(List<Contacto> lista)
        {
            string linenombre;
            string linetelefono;

            do
            {
            linenombre = Console.ReadLine();
            linetelefono = Console.ReadLine();

            Contacto cn = new Contacto(linenombre, linetelefono);

            lista.Add(cn);

            } while(evaluarIngreso(linenombre));
        }
        public bool evaluarIngreso(string valor)
        {
            if (valor.Equals("0"))
            return false;
            return true;
        }
    }
}