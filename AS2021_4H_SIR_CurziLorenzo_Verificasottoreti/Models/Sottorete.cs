using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2021_4H_SIR_CurziLorenzo_Verificasottoreti.Models
{
    public class Sottorete
    {
        /// <summary>
        /// Metodo che verifica l'appartenenza o meno di un indirizzo IP a una data sottorete
        /// </summary>
        /// <param name="subnetMask">sottorete</param>
        /// <param name="indirizzo">indirizzo IP</param>
        /// <returns>true se l'indirizzo appartiene alla sottorete, in caso contrario false</returns>
        public bool Verifica (string indirizzoNetwork, string subnetMask, string indirizzo)
        {
            //Calcolo le versioni binarie
            string subnetMaskBinaria = CalcoloBinario(subnetMask);
            string indirizzoIPBinario = CalcoloBinario(indirizzo);
            string indirizzoNetworkBinario = CalcoloBinario(indirizzoNetwork);

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

            //Comparo il risultato dell'operazione AND con la versione binaria dell'indirizzo IP di Netword 
            //Se sono uguali l'indirizzo IP apparterrà alla sottorete, in caso contrario non appartiene alla 
            //sottorete data
            for(int i = 0; i < risultatoAND.Length; i++)
            {
                if (risultatoAND[i] != indirizzoNetworkBinario[i])
                    return false;
            }              
            return true;
        }

        /// <summary>
        /// Metodo che data un indirizzo IP decimale ritorna il suo corrispetivo binario
        /// </summary>
        /// <param name="daConvertire">indirizzo da convertire</param>
        /// <returns>indirizzo IP binario</returns>
        string CalcoloBinario(string daConvertire)
        {
            string retVal = "";

            //converto in binario
            foreach (string s in daConvertire.Split("."))
                retVal += ConversioneBinaria(Convert.ToDouble(s)) + ".";

            //rimuovo l'ultimo punto ridondante
            daConvertire = daConvertire.Remove(daConvertire.Length - 1);
            return retVal;
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
        string ConversioneBinaria(double numero)
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
