using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PublicHolidaysUnitTests
{
    [TestClass]
    public sealed class PublicHolidaysTests
    {
        [TestMethod]
        public void Test()
        {
            DateTime datetime = DateTime.Now;
            bool value = datetime.IsSundayOrPublicHoliday(PublicHolidays.FederalStates.Bavaria);

            value = datetime.IsEasterMonday();

            bool feiertag2 = datetime.IsDayOfGermanUnity();

        }

        [TestMethod]
        public void IsDayOfGermanUnitytest2()
        {
            DateTime feiertag3 = new(2025, 04, 18);
           bool value = feiertag3.IsGoodFriday();

            DateTime feiertag4 = new(2025, 04, 21);
            bool value4 = feiertag4.IsEasterMonday();

            DateTime feiertag5 = new(2025, 06, 09);
            bool value5 = feiertag5.IsWhitMonday();// 55

            DateTime feiertag6 = new(2025, 06, 19);
            bool value6 = feiertag6.IsCorpusChristi();

            DateTime feiertag7 = new(2025, 05, 29);
            bool value7 = feiertag7.IsAscensionOfChrist();


            string hallo = "";
            /*
             * https://www.ferienwiki.de/feiertage/2025/de
             Internationaler Frauentag 	08.03.2025 (Samstag) 	Berlin und Mecklenburg-Vorpommern
           
             Buß- und Bettag in Deutschland 	19.11.2025 (Mittwoch) 	Sachsen

            Weltkindertag in Deutschland 	20.09.2025 (Samstag) 	Thüringen

            Jahrestag der Befreiung vom Nationalsozialismus und Ende des Zweiten Weltkriegs

            https://www.dgb.de/service/ratgeber/feiertage/
             */
        }

        [TestMethod]
        public void IsDayOfGermanUnitytest()
        {
            DateTime feiertag3 = new(2025, 10, 3);
            bool value = feiertag3.IsDayOfGermanUnity();
            Assert.IsTrue(value);
        }
    }
}
