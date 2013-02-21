using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MobilePhoneClass;

namespace _07.GSMUnitTest
{
    [TestClass]
    public class ValidateGSMClass
    {
        [TestMethod]
        public void TestMethod1()
        {
            GSM[] phones = new GSM[3];
            phones[0] = new GSM("tuhla", "paragvai", "spongeBob", 1000, new Battery("lol", 1, 23141), new Display(4.5, 5));
            phones[1] = new GSM("Kroasan5000", "4i4o Mitko", "apatrahil", 600, new Battery("ROFLCOPTER", 312, 22), new Display(2, 34));
            phones[2] = new GSM("Fafla", "francuzite", "jan-mishel-jar", 3, new Battery("GTFO", 1, 1), new Display(3213, 234533));

            
            foreach (var item in phones)
	        {
                Console.WriteLine(item.ToString());
	        }
            Console.WriteLine(GSM.iPhone4SInfo);


        }
    }
}
