using System;

    public class Contacto
    {
        public string Nombre{get; set;}
        public string Telefono{get; set;}
        public Contacto(string nombre, string telefono)
        {
            this.Nombre = nombre;
            this.Telefono = telefono;
        }
    }