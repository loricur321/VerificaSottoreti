using AS2021_4H_SIR_CurziLorenzo_Verificasottoreti.Models;
using Pastel;
using System;
using System.Text;

namespace AS2021_4H_SIR_CurziLorenzo_Verificasottoreti
{
    class Program
    {
        static void Main(string[] args)
        {
            Sottorete rete = new Sottorete();

            Console.WriteLine("Programma verifica sottoreti di Lorenzo Curzi 4H, 14/05/2021");

            string indirizzoNetwork = Richiestadati("Inserire l'indirizzo netowrk della sottorete es. (192.168.1.0): ");
            string subnetMask = Richiestadati("Inserire la sottorete es. (255.255.255.0): ");
            string indirizzoIP = Richiestadati("Inserire l'indirizzo IP che si vuole verificare es. (192.168.1.1): ");

            if (rete.Verifica(indirizzoNetwork,subnetMask, indirizzoIP))
                Console.WriteLine($"L'indirizzo IP {indirizzoIP} appartiene alla sottorete {indirizzoNetwork} con subnet mask {subnetMask}".Pastel("00FF00"));
            else
                Console.WriteLine($"L'indirizzo IP {indirizzoIP} non appartiene alla sottorete {indirizzoNetwork} con subnet mask {subnetMask}".Pastel("FF0000"));
        }

        /// <summary>
        /// Richiesta in ingresso dei dati
        /// </summary>
        /// <param name="prompt">stringa da comunicare all'utente</param>
        /// <returns>stringa inserita dall'utente</returns>
        static string Richiestadati(string prompt)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                string input = Console.ReadLine().Trim();

                bool flag = false;

                //Ricavo i valori ASCII dei caratteri inseriti
                byte[] CodiciASCII = Encoding.ASCII.GetBytes(input);

                //In caso anche un solo valore non sia compreso tra 48 ( 0 ) e 57 ( 9 ) e sia diverso da 46 ( . )
                //Imposto il flag a true indicando la presenza di un errore
                foreach(byte b in CodiciASCII)
                    if ((b < 48 || b > 57) && (b != 46))
                    {
                        flag = true;
                        break;
                    }

                if (!flag)
                    return input;
                else
                    Console.WriteLine("Inserimento errato!".Pastel("FF0000"));
            }
        }
    }
}
