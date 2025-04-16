namespace PublicHolidaysUnitTests
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void TestMethod1()
        {
            DateTime test = DateTime.Now;
            bool feiertag = test.IsSundayOrPublicHoliday(PublicHolidays.FederalStates.Bavaria);

            bool feiertag2 = test.IsDayOfGermanUnity();

        }
    }
}
