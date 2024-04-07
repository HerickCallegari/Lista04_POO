using System.Globalization;
using System.Net.Http.Headers;

namespace Biblioteca
    {
    public class Leitura
        {
        static void Main ( ) { }
        public static double ReadDouble ( )
            {
            string? entrada;
            double saida;
            try {
                entrada = Console.ReadLine ();
                saida = double.Parse (entrada!);
                }
            catch (ArgumentNullException) {
                throw new ArgumentException ("O valor não pode ser nulo. Digite novamente");
                }
            catch (FormatException) {
                throw new FormatException ("O valor invalido. Digite novamente");
                }
            catch (OverflowException) {
                throw new OverflowException ("Erro na entrada. Digite novamente");
                }
            return saida;
            }
        public static double LerDoubleComMsg ( string msg )
            {
            do {
                try {
                    Console.Write (msg);
                    return Leitura.ReadDouble ();
                    }
                catch (Exception ex) {
                    Console.WriteLine (ex.Message);
                    }
                } while (true);
            }

        public static int ReadInt ( )
            {
            string? entrada;
            int saida;
            try {
                entrada = Console.ReadLine ();
                saida = int.Parse (entrada!);
                }
            catch (ArgumentNullException) {
                throw new ArgumentException ("O valor não pode ser nulo. Digite novamente");
                }
            catch (FormatException) {
                throw new FormatException ("O valor invalido. Digite novamente");
                }
            catch (OverflowException) {
                throw new OverflowException ("Erro na entrada. Digite novamente");
                }
            return saida;
            }
        public static int LerIntComMsg ( string msg )
            {
            do {
                try {
                    Console.Write (msg);
                    return Leitura.ReadInt ();
                    }
                catch (Exception ex) {
                    Console.WriteLine (ex.Message);
                    }
                } while (true);
            }
        public static string LerStringComMsg ( string msg )
            {
            string saida;
            do {
                Console.Write (msg);
                saida = Console.ReadLine ()!;
                if (string.IsNullOrEmpty (saida)) {
                    Console.WriteLine ("Valor nulo. Digite novamente");
                    }
                } while (string.IsNullOrEmpty (saida));
            return saida;
            }
        }
    }