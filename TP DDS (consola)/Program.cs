using System;

namespace TP_DDS__consola_
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese constrasenia:  ");
            string pass = Console.ReadLine();
            while (pass.CompareTo("0") != 0)
            {
                if (ValidadorContrasenia.validarContrasenia(pass))
                    Console.WriteLine("contrasenia valida\n");
                else
                    Console.WriteLine("contrasenia invalida\n");

                Console.WriteLine("Ingrese constrasenia:  ");
                pass = Console.ReadLine();
            }
        }
    }
}
