using System;
using System.Collections.Generic;

namespace TP_DDS__consola_
{
    class Program
    {
        static void Main(string[] args)
        {
            //EntidadJuridica ent = new EntidadJuridica("asd", "asd", "asd", new List<EntidadBase>(), "asd", "asd","asd","Comercio", 1502750800, 320);
            //Console.WriteLine(ent.tipoOrganizacion.GetType().Name);

            int inversion = Convert.ToInt32(Console.ReadLine());
            int interes = Convert.ToInt32(Console.ReadLine());
            int anios = Convert.ToInt32(Console.ReadLine());
            
            for(int i = 0; i<anios ;i++)
            {
                inversion = inversion + inversion * (interes / 100);
            }

            Console.WriteLine(inversion);

        }
    }
}
