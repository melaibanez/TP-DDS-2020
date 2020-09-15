using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace TP_DDS__consola_
{
    public class ValidadorContrasenia
    {
        public static bool validarContrasenia(string pass)
        {
            return checkLongitud(pass) && !estaEnArchivoDeContrasenias(pass) && checkCaracteresRepetidos(pass) && checkSiEsASCII(pass);
        }


        private static bool checkCaracteresRepetidos(string pass)
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

        private static bool checkSiEsASCII(string pass)
        {
            bool esASCII = true;
            foreach (char element in pass)
            {
                if ((int)element < 32 || (int)element > 126)
                    esASCII = false;
            }
            return esASCII;
        }

        private static bool checkLongitud(string pass)
        {
            return pass.Length > 7 && pass.Length < 65;
        }

        private static bool estaEnArchivoDeContrasenias(string pass)
        {
            
            bool encontrado = false;
            string path = @"worst-pass.txt";
            if (File.Exists(path))
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    string s;
                    while ((s = sr.ReadLine()) != null && !encontrado)
                    {
                        encontrado = (pass.CompareTo(s) == 0);
                    }
                }
            }
            else
                Console.WriteLine("No esta el archivo de contrasenias");
            return encontrado;
        }
    }
}