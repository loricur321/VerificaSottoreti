using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2021_4H_SIR_CurziLorenzo_Verificasottoreti.Models
{
    static class Sottorete
    {
        /// <summary>
        /// Metodo che verifica l'appartenenza o meno di un indirizzo IP a una data sottorete
        /// </summary>
        /// <param name="subnetMask">sottorete</param>
        /// <param name="indirizzo">indirizzo IP</param>
        /// <returns>true se l'indirizzo appartiene alla sottorete, in caso contrario false</returns>
        static public bool Verifica (string subnetMask, string indirizzo)
        {
            //Calcolo la versione binaria della subnet mask
            string subnetMaskBinaria = "";
            foreach(string s in subnetMask.Split("."))
                subnetMaskBinaria += ConversioneBinaria(Convert.ToDouble(s)) + ".";

            

            //Calcolo la versione binaria dell'indirizzo IP
            string indirizzoIPBinario = "";
            foreach (string s in indirizzo.Split("."))
                indirizzoIPBinario += ConversioneBinaria(Convert.ToDouble(s)) + ".";

            //rimuovo l'ultimo punto ridondante
            subnetMaskBinaria = subnetMaskBinaria.Remove(subnetMaskBinaria.Length - 1);
            indirizzoIPBinario = indirizzoIPBinario.Remove(indirizzoIPBinario.Length - 1);


            //Variabile in cui salverò il risultato dell'operazione AND logico
            string risultatoAND = "";

            //eseguo l'AND logico
            for(int i = 0; i < subnetMaskBinaria.Length; i++)
            {
                if (subnetMaskBinaria[i] == '.' && indirizzoIPBinario[i] == '.')
                    risultatoAND += ".";
                else if (AND(subnetMaskBinaria[i], indirizzoIPBinario[i]))
                    risultatoAND += "1";
                else
                    risultatoAND += "0";
            }
            return false;
        }

        /// <summary>
        /// AND logico
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns>true se entrambi i bit sono impostati a 1, false nel caso contrario</returns>
        static bool AND (char num1, char num2)
        {
            if (num1 == '1' && num2 == '1')
                return true;
            else
                return false;
        }

        /// <summary>
        /// Metodo che consente di convertire un numero in binario su base 8 bit
        /// </summary>
        /// <param name="numero">numero da convertire</param>
        /// <returns>numero convertito</returns>
        static string ConversioneBinaria(double numero)
        {
            string binario = ""; //stringa concatenata in cui salvberò i bit del numero binario

            //numero binario : 128, 64 , 32, 16, 8, 4, 2, 1

            int n = 7;

            for (int i = 0; i <= 7; i++)
            {
                if (numero >= Math.Pow(2, n)) //confronto il numero con  la potenza di 2
                {
                    numero -= Math.Pow(2, n); //se è maggiore sottraggo la potenza di 2
                    binario += "1"; //e aggiungo 1 al numero binario
                }
                else
                    binario += "0"; //in caso contrario aggiungo 0 al numero binario
                n--;
            }

            return binario;
        }
    }
}
