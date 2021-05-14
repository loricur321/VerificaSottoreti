using AS2021_4H_SIR_CurziLorenzo_Verificasottoreti.Models;
using System;

namespace AS2021_4H_SIR_CurziLorenzo_Verificasottoreti
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Programma verifica sottoreti di Lorenzo Curzi 4H, 14/05/2021");

            Console.WriteLine("Inserire la sottorete: ");
            string subnetMask = "255.255.255.224";//Console.ReadLine().Trim();
            Console.WriteLine("Inserire l'indirizzo Ip che si vuole verificare: ");
            string indirizzoIP = "200.100.12.50";//Console.ReadLine().Trim();

            if (Sottorete.Verifica(subnetMask, indirizzoIP))
                Console.WriteLine($"L'indirizzo IP {indirizzoIP} appartiene alla sottorete: {subnetMask}");
            else
                Console.WriteLine($"L'indirizzo IP {indirizzoIP} non appartiene alla sottorete: {subnetMask}");
        }
    }
}
