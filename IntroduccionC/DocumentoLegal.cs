using System;
interface Imprimible
{
     void Imprimir();
}

interface Grabable
{
     void Grabar();
}


abstract class DocumentoLegal : Imprimible, Grabable // no puede ser herencia multiple, si multi "interface"
//                                                      puedo agregarle una clase también que va a ir adelante de todo
{
    // public int Numero;   todas las clases (pasado a private más abajo)
    public int Monto{get; set;}
    private int Numero;  // update: pasa a ser protegido. se puede referenciar/ver, pero no modificar
    private int codEnBaseDeDatos; // solo esta clase

    protected int fechaAlta; // todas las clases que heredan este tipo

    //    abstract public void Imprimir(); // todas las clases heredadas van a tener este método obligatoriamente
    /* virtual public void Imprimir() // todas las clases heredadas van a tener este método, pero pueden modificarlo
    {
        Console.WriteLine("Soy un DL:" + this.GetNumero());
    } 
    */
    virtual public void Imprimir()
    {
    }
    void Imprimible.Imprimir()
    {
        if (true /* NO HAY PAPEL*/){
            throw new NoHayPapelException();
        } else if (true /* NO HAY TINTA */){
            throw new Exception();
        } else if (true /* Impresora apagada */){
            throw new Exception();
        }
    }
    public void Grabar()
    {
    }

    public DateTime Fecha{  //get y set armado con campos cuyo nombre son escritos a mano??
        get {
         return Fecha;
        }
        private set{  // dentro de la misma función puedo redefinir la propiedad de una operatoria
            Fecha = value;
        }
    }


    public int GetNumero() // estoy armando un método público dentro de la clase (para que pueda consultar el numero)
                           //  y lo muestro
    {
        return Numero;
    }
    protected void SetNumero(int numero)
    {
        this.Numero = numero;
    }
    protected static void Hacer() // static = método de clase. protected = lo ve la misma clase y los que la heredan
    {
    }

    public DocumentoLegal(int numero) // "método constructor" para obligar a que el campo número no quede vacío
    {                                 // si yo no defino un método constructor, C# lo crea por defecto
        this.Numero = numero;
    }
    public void Enviar()
    {
        Console.WriteLine("DocumentoLegal.Enviar");
    }
    private void GuardarEnBaseDeDatos()
    {
        Console.WriteLine("DocuentoLegal.GuardarEnBaseDeDatos");
    }
}

    class ListaDeDocumentoLegal
        {   
    
    private Factura[] lista;

        public ListaDeDocumentoLegal(Factura[] milista)
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
    
        class Lista
        {   
    
    private Tipo[] lista;

        public ListaDeDocumentoLegal(Factura[] milista)
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