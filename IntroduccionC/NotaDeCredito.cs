using System;
class NotaDeCredito : DocumentoLegal
{
        public NotaDeCredito(int numero) : base(numero) 
    {                                           // método constructor heredado del método en DocumentoLegal

    }
    
// public override void Imprimir() // override es para hacer referencia al abstracto heredado. Podría tener otro propio
// {
//     Console.WriteLine("Soy la NC:" + this.GetNumero());// forma "prolija" es poner el this
// }

    static public NotaDeCredito LeerDeBaseDeDatos() // debe ser static para no depender de la existencia
    {                                               // de una instancia previa
        return new NotaDeCredito(1);                // ya estoy devolviendo desde el método
    }
}

class ListaDeNotaDeCredito     
    {   
    
    private Factura[] lista;

        public ListaDeNotaDeCredito (Factura[] milista)
        {
            this.lista = milista;
        }

        public int Total()
        {
            int total = 0;
            for (var f = 0; f < lista.Length; f++) {
                total += lista[f].Monto;
            }
            return total;
                   }
    }