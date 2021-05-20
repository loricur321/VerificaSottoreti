using Microsoft.VisualStudio.TestTools.UnitTesting;
using AS2021_4H_SIR_CurziLorenzo_Verificasottoreti.Models;

namespace VerificasottoretiTest
{
    [TestClass]
    public class UnitTest1
    {
        Sottorete rete = new Sottorete();
        [TestMethod]
        public void TestSottorete1()
        {
            /*
               Network: 192.168.1.0
               Subnet mask: 255.255.255.0
              
               192.168.1.20 AND 255.255.255.0 --> appartiene

               192.167.1.20 AND 255.255.255.0 --> non appartiene
             */

            Assert.AreEqual(true, rete.Verifica("192.168.1.0", "255.255.255.0", "192.168.1.20"), "Errore nella verifica della sottorete");

            Assert.AreEqual(false, rete.Verifica("192.168.1.0", "255.255.255.0", "192.167.1.20"), "Errore nella verifica della sottorete");
        }

        [TestMethod]
        public void TestSottorete2()
        {
            /*
                Network: 192.64.0.0
                Subnet mask: 255.192.0.0
              
                192.64.1.2  AND 255.192.0.0 --> appartiene

                192.65.1.2 AND 255.192.0.0 --> appartiene

                192.128.1.2 AND 255.192.0.0 --> non appartiene
             */

            Assert.AreEqual(true, rete.Verifica("192.64.0.0", "255.192.0.0", "192.64.1.2"), "Errore nella verifica della sottorete");

            Assert.AreEqual(true, rete.Verifica("192.64.0.0", "255.192.0.0", "192.65.1.2"), "Errore nella verifica della sottorete");

            Assert.AreEqual(false, rete.Verifica("192.64.0.0", "255.192.0.0", "192.128.1.2"), "Errore nella verifica della sottorete");
        }
    }
}
