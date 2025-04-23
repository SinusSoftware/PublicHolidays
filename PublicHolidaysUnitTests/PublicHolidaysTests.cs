using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace PublicHolidaysUnitTests
{
    /*
      https://www.ferienwiki.de/feiertage/2025/de
      https://www.dgb.de/service/ratgeber/feiertage/
     */

    [TestClass]
    public sealed class PublicHolidaysTests
    {
        /*
        [TestMethod]
        public void IsSundayOrPublicHolidayTest_Bavaria()
        {
            DateTime datetime = new(2026,04,06);
            bool value = datetime.IsSundayOrPublicHoliday(PublicHolidays.FederalStates.Bavaria);
            Assert.IsTrue(value);
        }

        [TestMethod]
        public void IsEsternTest()
        {
            DateTime datetime = new(2025, 04, 18);
            bool value = datetime.IsGoodFriday();
            Assert.IsTrue(value);

            DateTime datetime2 = new(2025, 04, 21);
            bool value2 = datetime2.IsEasterMonday();
            Assert.IsTrue(value2);

            DateTime datetime3 = new(2025, 06, 09);
            bool value3 = datetime3.IsWhitMonday();
            Assert.IsTrue(value3);

            DateTime datetime4 = new(2025, 06, 19);
            bool value4 = datetime4.IsCorpusChristi();
            Assert.IsTrue(value4);

            DateTime datetime5 = new(2025, 05, 29);
            bool value5 = datetime5.IsAscensionOfChrist();
            Assert.IsTrue(value5);
        }

        [TestMethod]
        public void IsRepentanceAndPrayerDayTest()
        {
            DateTime datetime = new(2025, 11, 19);
            bool value = datetime.IsRepentanceAndPrayerDay();
            Assert.IsTrue(value);
        }

        [TestMethod]
        public void IsDayOfGermanUnityTest()
        {
            DateTime feiertag3 = new(2025, 10, 3);
            bool value = feiertag3.IsDayOfGermanUnity();
            Assert.IsTrue(value);
        }
        */
    }
}
