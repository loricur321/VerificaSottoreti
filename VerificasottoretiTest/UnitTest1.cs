using Microsoft.VisualStudio.TestTools.UnitTesting;
using AS2021_4H_SIR_CurziLorenzo_Verificasottoreti.Models;

namespace VerificasottoretiTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestSottorete1()
        {
            /*
               Network: 192.168.1.0
               Subnet mask: 255.255.255.0
              
               192.168.1.20 AND 255.255.255.0 --> appartiene

               192.167.1.20 AND 255.255.255.0 --> non appartiene
             */

            Assert.AreEqual(true, Sottorete.Verifica("192.168.1.0", "255.255.255.0", "192.168.1.20"), "Errore nella verifica della sottorete");

            Assert.AreEqual(false, Sottorete.Verifica("192.168.1.0", "255.255.255.0", "192.167.1.20"), "Errore nella verifica della sottorete");
        }
    }
}
