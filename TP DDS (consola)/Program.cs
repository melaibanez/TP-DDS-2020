using System;

namespace TP_DDS__consola_
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese constrasenia: \n");
            string pass = Console.ReadLine();
            while (pass.CompareTo("0") != 0)
            {
                if (validadorContrasenia.validarContrasenia(pass))
                    Console.WriteLine("contrasenia valida");
                else
                    Console.WriteLine("contrasenia invalida");

                Console.WriteLine("Ingrese constrasenia: \n");
                pass = Console.ReadLine();
            }
        }
    }
}
