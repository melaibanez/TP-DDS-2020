using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace TP_DDS__consola_
{
    class validadorContrasenia
    {
        public static bool validarContrasenia(string pass)
        {
            return checkLongitud(pass) && checkCaracteresRepetidos(pass) && !estaEnArchivoDeContrasenias(pass);
        }
        
        private static bool checkCaracteresRepetidos(string pass) //chequea si hay 
        {
            for (int i = 0; i < pass.Length - 2; i++)
            {
                if (pass[i] == pass[i + 1] && pass[i] == pass[i + 2])
                {
                    return false;
                }
            }
            return true;
        }

        private static bool checkLongitud(string pass)
        {
            return pass.Length > 7 && pass.Length < 65;
        }

        private static bool estaEnArchivoDeContrasenias(string pass)
        {
            bool encontrado = false;
            string path = @"C:\Users\Eze\Desktop\UTN\Diseño de Sistemas\TP DDS (consola)\worst-pass.txt";
            if (File.Exists(path))
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    string s;
                    while ((s = sr.ReadLine()) != null && !encontrado)
                    {
                        encontrado = pass.CompareTo(s) == 0;
                    }
                }
            }
            else
                Console.WriteLine("No esta el archivo de contrasenias");
            return encontrado;
        }

    }
}
