using System;

class Factura : DocumentoLegal // NombreClase : NombreClaseAHeredar ---> " : " significa "es un..."
{
    public Factura(int numero) : base(numero) 
    {                                           // método constructor heredado del método en DocumentoLegal

    }
    
     public override void Imprimir()
    {
        Console.WriteLine("Soy la FC:" + this.GetNumero());
    }
    

    public void Pagar()
    {
        DocumentoLegal.Hacer();     // me permite llamarlo porque el método Hacer es static, el prefijo es opcional   
        Console.WriteLine("Factura.Pagar");
    }

    class FacturaExportacion : Factura
    {
        public string Pais {get; set;}
        public FacturaExportacion(int numero) : base(numero){}

            public override void Imprimir()
            {
                Console.WriteLine("Soy la FC-E:" + this.GetNumero());
            }
        }
    
    }

    class ListaDeFacturas
    {
        public int Monto;
        private Factura[] lista;

        public ListaDeFacturas(Factura[] milista)
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
    