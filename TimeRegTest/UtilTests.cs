using System;
using NUnit.Framework;
using TimeForing.Common;

namespace TimeRegTest
{
    [TestFixture ]
    public class UtilTests
    {
        [Test]
        public void TestWeekFromDate()
        {
            int weekNr1 = Util.WeekInYear(new DateTime(2009, 10, 1));
            int weekNr2 = Util.WeekInYear(new DateTime(2009, 11, 1));
            int weekNr3 = Util.WeekInYear(new DateTime(2009, 1, 5));
            int weekNr4 = Util.WeekInYear(new DateTime(2009, 2, 3));
            Assert.AreEqual(40,weekNr1);
            Assert.AreEqual(44,weekNr2);
            Assert.AreEqual(2, weekNr3);
            Assert.AreEqual(6, weekNr4);
        }
        [Test]
        public void TestFirstDayInWeek()
        {
            int w1 = 3;
            int w2 = 12;
            int w3 = 34;
            int w4 = 45;
            DateTime d1 = Util.StartDateInWeek(w1,2009);
            DateTime d2 = Util.StartDateInWeek(w2, 2009);
            DateTime d3 = Util.StartDateInWeek(w3, 2009);
            DateTime d4 = Util.StartDateInWeek(w4, 2009);

            Assert.AreEqual(new DateTime(2009, 1, 12), d1);
            Assert.AreEqual(new DateTime(2009, 3, 16), d2);
            Assert.AreEqual(new DateTime(2009, 8, 17), d3);
            Assert.AreEqual(new DateTime(2009, 11, 2), d4);


        }
    }
}
