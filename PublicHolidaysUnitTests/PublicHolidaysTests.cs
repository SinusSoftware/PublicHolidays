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
        public void IsDayOfGermanUnitytest()
        {
            DateTime feiertag3 = new(2025, 10, 3);


            bool value = feiertag3.IsDayOfGermanUnity();

        }
    }
}
