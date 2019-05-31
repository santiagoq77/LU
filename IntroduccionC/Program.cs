using System;   // AKA <include>
using System.Collections;
using System.Collections.Generic;
using System.Linq; // language integrated query, me permite incorporar consultas dentro del código.. ejemplo de list.where(DL)

namespace IntroduccionC    // 100% organizativo.
{
    class Program
    {
        static void Main(string[] args)
        {
        /*  int sueldo = 101;
            int empleados = 3;
            int transferencia;
            int[] sueldos = new int[5];

            sueldos[0] = 100;
            sueldos[1] = 200;
            transferencia= sueldo*empleados;
            if (0 == (transferencia % 2)) {
                Console.WriteLine("Par");
            } else {
                Console.WriteLine("Impar");
            }
            Console.WriteLine("Monto: " + transferencia);
        

            int[] sumar = new int[10];
            int sumtotal = 0;
            for(int i = 0; i<10; i++) {
                sumar[i] = i;
            }

            for(int i = 0; i<10; i++) {
                sumtotal = sumar[i] + sumtotal;
            }
            Console.WriteLine(sumtotal); 
            if(0 == (sumtotal % 3)) {
            Console.WriteLine("Número divisible por 3"); }
        

        static int Division(int dividendo, int divisor) {

            int cociente = 0;
            int resto = 0;
            resto = dividendo - divisor

            return (resto < divisor) ? cociente : cociente++
        */
        int cociente = 0;
        var respuesta = Division(25, 3, cociente);

        // cociente = Division(19, 5, cociente);
        Console.WriteLine(respuesta.cociente2);
        Console.WriteLine(respuesta.resto2);

        // var dl = new DocumentoLegal(3);  // "dl" y "fc" son objetos - update: agrego el 3 por el método constructor
        // update: no tengo más documento legal por no tener el método
        // var fc = new Factura(1);        
        var nc = new NotaDeCredito(1); 
        var nc2 = new NotaDeCredito(2); // Puedo tener X cantidad de instancias

        nc.Imprimir();
        nc2.Imprimir();
        // bool si = (dl is DocumentoLegal);
            //si = (dl is Factura);
            // si = (fc is Factura);
            // si = (fc is DocumentoLegal);

        HacerAlgoConDocumentos(nc);   // es igual a decir "var algo = (DocumentoLegal)nc;

        try {
            var oncc = NotaDeCredito.LeerDeBaseDeDatos();
            NotaDeCredito onc = null;
            HacerAlgoConDocumentos(onc);

            onc.Imprimir();
        } catch(NoHayPapelException){
            Console.WriteLine("Mica comprá papel.");
        } 
        catch{
            Console.WriteLine("Error 2");
        }

        Dictionary<int, string> ds = new Dictionary<int, string>;

        ds.Add(1, "Diego");
        ds.Add(2, "Julian");
        ds.Add(3, "Maximiliano"); 

        string s = ds[9];

        DateTime fecha = new DateTime(2019, 2, 28);
        fecha.AddDays(1);

    List<string> nombres = new List<string>();
    nombres.Add("Diego");
    nombres.Add("Julian");
    nombres.Add("Maximiliano");

    for(int idx= 0; idx < nombres.Count; idx ++)
    {
        var nom = nombres[idx];

        Console.WriteLine(nom);
    }

    foreach(var nom in nombres.Where( (nn) => nn[0] == 'D' )) //va a haber un parámetro nn de la lista string nombres
    {                                                         // el where devuelve un IEnumerable
        Console.WriteLine(nom);
    }
    string diego = "Diego";
    foreach (var ch in diego)
    {
        Console.WriteLine(ch);
    }

// Ejercicio: hacer un programa que escriba en un archivo de texto un listado de eprsonas y teléfonos.
// El programa tiene que también poder leer el archivo y cargarlo en una colección
//Si modifico el archivo, tengo que poder leerlo nuevamente


        object algo = (DocumentoLegal)nc; // object puedo referenciar cualquier cosa y 4 métodos 
        algo = nc;
        algo = "Diego";
        algo = 3;

        var facturas = new Factura[3];
        facturas[0] = new Factura(1);
        facturas[1] = new Factura(2);
        facturas[2] = new Factura(3);

        ListaDeFacturas ListaF = new ListaDeFacturas(facturas);
        ListaF.Total();
        var lista = new Lista<DocumentoLegal>(null);

        var list = new List<DocumentoLegal>();
        list.Sort();

        Func<int, int> f = delegate(int i){ // forma genérica de llamar a cualquier función
            return i + 1;
        };
        f(4);

        Func<DocumentoLegal, bool> siEsPar = delegate(DocumentoLegal dl){ // hago consulta partiendo de si el valor a revisar   es par o no
                return (dl.Monto % 2) == 0;
        };
        list.Where(siEsPar); // devuelve otra lista donde todos son pares

        Func<int, int, int> f2 = delegate(int i, int j){
                        return i + 1;
        };
        f(4);
        var nnc = NotaDeCredito.LeerDeBaseDeDatos(); // agrego NotaDeCredito para identificar de dónde sale el método
        //NotaDeCredito onc = null;   // estoy generando un objeto con las propiedades de su clase, pero nula (rompe)
        //onc.Imprimir();   - Error más común. onc está generado con herencia pero no tiene ningún valor
        }

        static void HacerAlgoConDocumentos(DocumentoLegal dl)
        {
            dl.Imprimir(); //me aseguro que todos los documentos legales existentes van a tener el método disponible
        }



        static resultado Division(int dividendo, int divisor, int cociente) {
            int resto = 0;
            
            resto = dividendo - divisor;

            var arruinoelfutbol = new resultado
            {
                cociente2 = cociente,
                resto2 = dividendo
            };
            

            return (resto + dividendo < divisor) ? 
                arruinoelfutbol : 
                Division(dividendo - divisor, divisor, cociente+1);

        }   
    }
    struct resultado {
            public int cociente2;
            public int resto2;  
            }
}

class NoHayPapelException : Exception   // puedo hacer una clase propia que herede de excepcion
{
    public string Impresora;
}